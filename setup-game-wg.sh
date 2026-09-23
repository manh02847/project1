#!/usr/bin/env bash
set -Eeuo pipefail
umask 077

# Run as root on a fresh Ubuntu or Debian VPS.
if (( EUID != 0 )); then echo 'Run as root.' >&2; exit 1; fi
if ! command -v apt-get >/dev/null; then echo 'Ubuntu or Debian required.' >&2; exit 1; fi
if [[ -e /etc/wireguard/wg0.conf ]]; then
  echo '/etc/wireguard/wg0.conf exists; refusing to overwrite it.' >&2
  exit 1
fi

ENDPOINT="${ENDPOINT:?Set ENDPOINT to your VPS public IPv4}"
PORT="${PORT:-51820}"
case "$PORT" in ''|*[!0-9]*) echo 'Invalid PORT.' >&2; exit 1;; esac
if (( PORT < 1 || PORT > 65535 )); then echo 'Invalid PORT.' >&2; exit 1; fi

export DEBIAN_FRONTEND=noninteractive
apt-get update
apt-get install -y wireguard iptables iproute2 qrencode
WAN_IF="$(ip -4 route show default | awk 'NR==1 {for(i=1;i<=NF;i++) if($i=="dev") {print $(i+1); exit}}')"
if [[ -z "$WAN_IF" || ! "$WAN_IF" =~ ^[a-zA-Z0-9_.:-]+$ ]]; then
  echo 'Cannot identify the public-facing network interface.' >&2; exit 1
fi

install -d -m 700 /etc/wireguard
SERVER_KEY="$(wg genkey)"
SERVER_PUBLIC="$(printf '%s' "$SERVER_KEY" | wg pubkey)"
CLIENT_KEY="$(wg genkey)"
CLIENT_PUBLIC="$(printf '%s' "$CLIENT_KEY" | wg pubkey)"
PRESHARED="$(wg genpsk)"

cat > /etc/wireguard/wg0.conf <<EOF
[Interface]
Address = 10.77.0.1/24
ListenPort = $PORT
PrivateKey = $SERVER_KEY
PostUp = iptables -I FORWARD -i wg0 -j ACCEPT; iptables -I FORWARD -o wg0 -j ACCEPT; iptables -t nat -A POSTROUTING -s 10.77.0.0/24 -o $WAN_IF -j MASQUERADE
PostDown = iptables -D FORWARD -i wg0 -j ACCEPT; iptables -D FORWARD -o wg0 -j ACCEPT; iptables -t nat -D POSTROUTING -s 10.77.0.0/24 -o $WAN_IF -j MASQUERADE

[Peer]
PublicKey = $CLIENT_PUBLIC
PresharedKey = $PRESHARED
AllowedIPs = 10.77.0.2/32
EOF
chmod 600 /etc/wireguard/wg0.conf

cat > /etc/wireguard/manh-iphone.conf <<EOF
[Interface]
PrivateKey = $CLIENT_KEY
Address = 10.77.0.2/32
DNS = 1.1.1.1
MTU = 1380

[Peer]
PublicKey = $SERVER_PUBLIC
PresharedKey = $PRESHARED
Endpoint = $ENDPOINT:$PORT
AllowedIPs = 0.0.0.0/0
PersistentKeepalive = 25
EOF
chmod 600 /etc/wireguard/manh-iphone.conf

printf 'net.ipv4.ip_forward = 1\n' > /etc/sysctl.d/90-game-wireguard.conf
sysctl -p /etc/sysctl.d/90-game-wireguard.conf
if command -v ufw >/dev/null && ufw status | grep -q '^Status: active'; then
  ufw allow "$PORT/udp"
  ufw route allow in on wg0 out on "$WAN_IF"
fi
systemctl enable --now wg-quick@wg0
echo "WireGuard running on UDP $PORT. iPhone profile: /etc/wireguard/manh-iphone.conf"
echo 'Open that UDP port in the AWS security group. Keep the profile private.'
wg show wg0
