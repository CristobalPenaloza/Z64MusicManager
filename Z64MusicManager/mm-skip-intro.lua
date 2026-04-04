while true do
    if mainmemory.read_u16_be(0x71FDD0)==0x2408 then
        mainmemory.write_u16_be(0x71FDCE, 0xFFFF)
        mainmemory.write_u16_be(0x71FDD4, 0xA443)
        mainmemory.write_u16_be(0x71FDD8, 0x3C0A)
        mainmemory.write_u16_be(0x71FDDA, 0x0002)
        mainmemory.write_u16_be(0x71FDE6, 0x8081)
        mainmemory.write_u16_be(0x71FDEA, 0x3C98)
        mainmemory.write_u16_be(0x71FDEC, 0x254A)
        mainmemory.write_u16_be(0x71FDEE, 0x4558)
    end
    emu.frameadvance()
end