local CINEMATIC_MODE_ADDRESS = 0x11B92F
local input_fired = false

while true do
    local current_mode = mainmemory.read_u8(CINEMATIC_MODE_ADDRESS)

    -- The exact frame the Title Screen scene becomes active (0x01)
    if current_mode == 0x01 then
        if not input_fired then
            -- Slam both variations of the Start button to break the screen barrier
            joypad.set({["P1 Start"] = true})
            joypad.set({["Start"] = true}, 1)
            input_fired = true
        else
            -- Release it immediately on the next frame so it registers as a clean tap
            joypad.set({["P1 Start"] = false})
            joypad.set({["Start"] = false}, 1)
            input_fired = false
        end
    end
    
    emu.frameadvance()
end