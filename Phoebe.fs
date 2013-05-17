module Phoebe
#nowarn "9"

open System
open System.Runtime.InteropServices

let inline (/>) f a = f a

[<Flags>]
type AllocationType =
| Commit        = 0x1000

[<Flags>]
type ProcessAccess =
| VMOperation   = 0x8
| VMRead        = 0x10
| VMWrite       = 0x20

[<Flags>]
type MemoryProtection =
| ReadWrite     = 0x04

let SE_PRIVILEGE_ENABLED    = 0x00000002u
let TOKEN_QUERY             = 0x00000008
let TOKEN_ADJUST_PRIVILEGES = 0x00000020
let SE_TIME_ZONE_NAMETEXT   = "SeTimeZonePrivilege"

[<StructLayout(LayoutKind.Sequential)>]
type LUID =
    struct
        val LowPart     : UInt32
        val HighPart    : UInt32
    end

[<StructLayout(LayoutKind.Sequential, Pack = 1)>]
type TOKEN_PRIVILEGES =
    struct
        val PrivilegeCount  : UInt32
        val Luid            : LUID
        val Attributes      : UInt32
    end
    
type MOUSEINPUT =
    struct
        val dx          : int
        val dy          : int
        val mouseData   : int
        val dwFlags     : int
        val time        : int
        val dwExtraInfo : IntPtr
    end

type KEYBDINPUT =
    struct
        val mutable wVk         : char
        val mutable wScan       : Int16
        val mutable dwFlags     : int
        val mutable time        : int
        val mutable dwExtraInfo : IntPtr
    end

type HARDWAREINPUT =
    struct
        val uMsg    : int
        val wParamL : Int16
        val wParamH : Int16
    end


[<StructLayout(LayoutKind.Explicit)>]
type INPUT =
    struct
        [<FieldOffset(0)>]
        val mutable typefield   : int
        [<FieldOffset(4)>]
        val mutable mi          : MOUSEINPUT
        [<FieldOffset(4)>]
        val mutable ki          : KEYBDINPUT
        [<FieldOffset(4)>]
        val mutable hi          : HARDWAREINPUT
    end