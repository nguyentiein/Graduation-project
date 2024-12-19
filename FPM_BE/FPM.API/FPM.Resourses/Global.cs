#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses;
public static class Global
{
    public static string ConnectionString { get; set; }
    public static string Version { get; set; }
    public static bool IsDebug { get; set; }
}


public sealed class JwtConfig
{
    public static string Secret { get; set; }
    public static string Issuer { get; set; }
    public static string Audience { get; set; }
    public static int AccessTokenExpiration { get; set; }
    public static int RefreshTokenExpiration { get; set; }
}

public sealed class SmtpConfig
{
    public static string Email { get; set; }
    public static string DisplayName { get; set; }
    public static string Password { get; set; }
    public static string Host {  get; set; }
    public static int Port { get; set; }
}
