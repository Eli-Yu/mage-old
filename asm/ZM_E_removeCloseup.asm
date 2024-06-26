.gba
.open "ZM_E.gba","ZM_E_removeCloseup.gba",0x8000000

.definelabel HideHudFlag,0x300004A

.org 0x8060700
    ldr     r0,=HideHudFlag
    strb    r5,[r0]     ; makes HUD visible from start
    b       0x806082A   ; skips code that overwrites VRAM
    .pool

.org 0x805FA98
    mov     r0,0xD
    strb    r0,[r2,2]   ; skips stages involving Samus's eyes
    b       0x805FE2E


.close
