using System;
using System.Configuration;
using System.Windows.Forms;

namespace QLSinhVien.Common
{
    public static class ConfigSecurityHelper
    {
        public const string DpapiProvider = "DataProtectionConfigurationProvider";
        public const string RsaProvider = "RsaProtectedConfigurationProvider";

        public static bool IsConnectionStringsProtected()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.GetSection("connectionStrings");
            return section != null && section.SectionInformation.IsProtected;
        }

        public static void ProtectConnectionStrings(string provider = DpapiProvider)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection section = config.GetSection("connectionStrings");

                if (section != null && !section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.ProtectSection(provider);
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                }

                Logger.Info("Đã mã hóa thành công phần connectionStrings bằng provider: " + provider);
                MessageBox.Show("Đã mã hóa connectionStrings thành công!", "Bảo mật cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.Error("Lỗi khi mã hóa connectionStrings", ex);
                MessageBox.Show("Không thể mã hóa cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UnprotectConnectionStrings()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection section = config.GetSection("connectionStrings");

                if (section != null && section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.UnprotectSection();
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                }

                Logger.Info("Đã giải mã phần connectionStrings.");
                MessageBox.Show("Đã giải mã connectionStrings thành công!", "Bảo mật cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.Error("Lỗi khi giải mã connectionStrings", ex);
                MessageBox.Show("Không thể giải mã cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}