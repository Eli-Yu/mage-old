.gba
.open "MF_J.gba","MF_J_locationNames.gba",0x8000000

.definelabel AreaID,0x3000032

; modify code that checks if door displays location name
.org 0x801493C
    bl      FindLocationName
    b       0x80149A0

; custom routine to find text number for the door
.org 0x801447C
FindLocationName:
    push    r14
    ldr     r0,=AreaID
    ldrb    r2,[r0]     ; r2 = CurrArea
    ldrb    r3,[r0,1]   ; r3 = CurrRoom
    ldr     r1,=LocationNameList
@@Loop:
    ldrb    r0,[r1]     ; r0 = AreaID
    cmp     r0,0xFF
    beq     @@Return
    cmp     r0,r2
    bne     @@Iterate
    ldrb    r0,[r1,1]   ; r0 = RoomID
    cmp     r0,r3
    bne     @@Iterate
    ldrb    r0,[r1,2]   ; r0 = TextNumber
    b       @@Return
@@Iterate:
    add     r1,3
    b       @@Loop
@@Return:
    pop     r1
    bx      r1
    .pool

; door pop-ups from the original rom
LocationNameList:
    ; format: AreaID, RoomID, TextNumber
    .db 0x00,0x06,0x0B
    .db 0x00,0x07,0x00
    .db 0x00,0x0A,0x00
    .db 0x00,0x19,0x00
    .db 0x00,0x1A,0x00
    .db 0x00,0x1B,0x00
    .db 0x00,0x1C,0x00
    .db 0x00,0x1D,0x00
    .db 0x00,0x1E,0x00
    .db 0x00,0x2E,0x13
    .db 0x00,0x30,0x07
    .db 0x00,0x31,0x14
    .db 0x00,0x36,0x15
    .db 0x00,0x37,0x07
    .db 0x00,0x3B,0x14
    .db 0x00,0x3C,0x09
    .db 0x00,0x3D,0x00
    .db 0x00,0x3E,0x08
    .db 0x00,0x43,0x08
    .db 0x00,0x44,0x07
    .db 0x00,0x47,0x12
    .db 0x00,0x4A,0x11
    .db 0x00,0x4B,0x00
    .db 0x00,0x4C,0x0A
    .db 0x00,0x4E,0x16
    .db 0x00,0x4F,0x16
    .db 0x00,0x52,0x11

    .db 0x01,0x1F,0x01
    .db 0x01,0x29,0x01
    .db 0x01,0x30,0x01
    .db 0x01,0x31,0x01

    .db 0x02,0x18,0x02
    .db 0x02,0x1D,0x02
    .db 0x02,0x24,0x02
    .db 0x02,0x34,0x02
    .db 0x02,0x35,0x02

    .db 0x03,0x11,0x18
    .db 0x03,0x14,0x03
    .db 0x03,0x19,0x19
    .db 0x03,0x1D,0x18
    .db 0x03,0x25,0x03
    .db 0x03,0x26,0x03

    .db 0x04,0x17,0x04
    .db 0x04,0x1B,0x04
    .db 0x04,0x21,0x17
    .db 0x04,0x2B,0x04
    .db 0x04,0x2C,0x04

    .db 0x05,0x19,0x05
    .db 0x05,0x1F,0x05
    .db 0x05,0x25,0x05
    .db 0x05,0x32,0x05

    .db 0x06,0x11,0x06
    .db 0x06,0x16,0x06
    .db 0x06,0x24,0x06
    .db 0x06,0x25,0x06

    .db 0xFF,0xFF,0xFF


.close
