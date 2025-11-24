// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

namespace Portal.Federation.Permissions;

[Flags]
public enum Permission
{
   None   = 0,
   View   = 1 << 0, // 0001
   Create = 1 << 1, // 0010
   Update = 1 << 2, // 0100
   Delete = 1 << 3, // 1000
   All    = View | Create | Update | Delete
}