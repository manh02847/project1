document.addEventListener("DOMContentLoaded", function () {
    const currentPath = window.location.pathname.toLowerCase();
    const links = document.querySelectorAll("nav a, .area-sidebar a");

    links.forEach(function (link) {
        const href = link.getAttribute("href");
        if (!href) return;

        const linkPath = new URL(link.href).pathname.toLowerCase();
        const isHome = linkPath === "/" && (currentPath === "/" || currentPath === "/nnmhome" || currentPath === "/nnmhome/index");

        if (isHome || (linkPath !== "/" && currentPath.startsWith(linkPath))) {
            link.classList.add("active");
        }
    });
});
