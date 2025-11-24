// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

namespace Portal.Federation.Permissions;

[Flags]
public enum Permission
{
   None = 0,
   View = 1 << 0,
   Create = 1 << 1,
   Update,
   Delete,
   All = View | Create | Update | Delete
}