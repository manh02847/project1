namespace NnmLesson12EFCore.Helpers;

public static class NnmImageUpload
{
    public static string? Validate(IFormFile? file, bool required)
    {
        if (file == null || file.Length == 0)
        {
            return required ? "Vui lòng chọn ảnh" : null;
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        string[] allowed = [".jpg", ".jpeg", ".png", ".gif", ".webp"];
        if (!allowed.Contains(extension))
        {
            return "Chỉ chấp nhận ảnh JPG, JPEG, PNG, GIF hoặc WEBP";
        }

        if (file.Length > 5 * 1024 * 1024)
        {
            return "Ảnh không được lớn hơn 5 MB";
        }

        using var stream = file.OpenReadStream();
        Span<byte> header = stackalloc byte[12];
        var count = stream.Read(header);
        var valid = extension switch
        {
            ".jpg" or ".jpeg" => count >= 3 && header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF,
            ".png" => count >= 8 && header[..8].SequenceEqual(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 }),
            ".gif" => count >= 6 && (header[..6].SequenceEqual("GIF87a"u8) || header[..6].SequenceEqual("GIF89a"u8)),
            ".webp" => count >= 12 && header[..4].SequenceEqual("RIFF"u8) && header[8..12].SequenceEqual("WEBP"u8),
            _ => false
        };

        return valid ? null : "Nội dung tệp không đúng định dạng ảnh";
    }

    public static async Task<string> SaveAsync(IFormFile file, string webRoot, string folder)
    {
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName).ToLowerInvariant();
        var directory = Path.Combine(webRoot, folder);
        Directory.CreateDirectory(directory);
        using var stream = new FileStream(Path.Combine(directory, fileName), FileMode.CreateNew);
        await file.CopyToAsync(stream);
        return fileName;
    }
}
