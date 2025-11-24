// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

namespace Portal.Federation.Identity;

public static class IdentitySeed
{
   public static List<FederationUser> Users =>
   [
      new() { },
      new() { }
   ];

   public static List<FederationRole> Roles =>
   [
      new() { Name = "Admin" }
   ];
}