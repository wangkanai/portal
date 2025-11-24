// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.AspNetCore.Identity;

namespace Portal.Federation.Identity;

public static class IdentitySeed
{
   private static PasswordHasher<FederationUser> hasher   = new();
   private static string                         password = hasher.HashPassword(null!, "P@ssw0rd");

   public static List<FederationUser> Users =>
   [
      new() { UserName = "admin", PasswordHash = password },
      new() { }
   ];

   public static List<FederationRole> Roles =>
   [
      new() { Name = "Admin" },
      new() { Name = "User" }
   ];
}