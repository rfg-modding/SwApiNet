# /bin/bash
clear
rfg_path='/c/Program Files (x86)/Steam/steamapps/common/Red Faction Guerrilla Re-MARS-tered'
bash publish.sh || exit 1 && ( cd "$rfg_path" && ./rfg.exe )