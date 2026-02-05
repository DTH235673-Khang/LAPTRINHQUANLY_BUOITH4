using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    
    
        public static class StringExtensions
        {
            public static string GenerateSlug(this string phrase)
            {
                if (string.IsNullOrWhiteSpace(phrase)) return "";

                // 1. Chuyển về chữ thường
                string str = phrase.ToLower();

                // 2. Thay thế các ký tự tiếng Việt có dấu thành không dấu
                str = RemoveVietnameseSigns(str);

                // 3. Xóa các ký tự đặc biệt, chỉ giữ lại chữ cái, số và khoảng trắng
                str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

                // 4. Thay thế nhiều khoảng trắng thành 1 khoảng trắng
                str = Regex.Replace(str, @"\s+", " ").Trim();

                // 5. Thay khoảng trắng bằng dấu gạch ngang
                str = str.Replace(" ", "-");

                // 6. Xóa các dấu gạch ngang trùng lặp (--)
                str = Regex.Replace(str, @"-+", "-");

                return str;
            }

            private static string RemoveVietnameseSigns(string str)
            {
                string[] vietnameseSigns = new string[]
                {
                "aAeEoOuUiIyYdD",
                "áàảãạâấầẩẫậăắằẳẵặ",
                "ÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶ",
                "éèẻẽẹêếềểễệ",
                "ÉÈẺẼẸÊẾỀỂỄỆ",
                "óòỏõọôốồổỗộơớờởỡợ",
                "ÓÒỎÕỌÔỐỒỔỖỘƠỚỞỠỢ",
                "úùủũụưứừửữự",
                "ÚÙỦŨỤƯỨỪỬỮỰ",
                "íìỉĩị",
                "ÍÌỈĨỊ",
                "ýỳỷỹỵ",
                "ÝỲỶỸỊ",
                "đ",
                "Đ"
                };

                for (int i = 1; i < vietnameseSigns.Length; i++)
                {
                    for (int j = 0; j < vietnameseSigns[i].Length; j++)
                    {
                        str = str.Replace(vietnameseSigns[i][j], vietnameseSigns[0][i - 1]);
                    }
                }
                return str;
            }
        }
    }




