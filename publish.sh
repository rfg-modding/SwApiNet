# /bin/bash -ex
rm -rf _publish
dotnet clean src
dotnet publish src/SwApiNet -o _publish

rfg_path='/c/Program Files (x86)/Steam/steamapps/common/Red Faction Guerrilla Re-MARS-tered'
dll="$rfg_path/sw_api.dll"
original="$rfg_path/sw_api_original.dll"
gog_dll_hash='67f9f8e976157ebf6e8ea2fc93681a102f513fefd11998273eeb8da743cbe71f'
original_hash=$(sha256sum "$original" 2>/dev/null | cut -d' ' -f1)

if [ -z "${original_hash}" ]; then
    # original.dll does not exist, create it
    dll_hash=$(sha256sum "$dll" 2>/dev/null | cut -d' ' -f1)
    if [ $dll_hash != $gog_dll_hash ]; then
        echo "Your sw_api.dll is not expected version! use the one from GOG"
        exit 1
    fi
    cp "$dll" "$original"
    echo "Created $original"
fi

original_hash=$(sha256sum "$original" 2>/dev/null | cut -d' ' -f1)
if [ $original_hash != $gog_dll_hash ]; then
    echo "Your sw_api_original.dll is not expected version! use the one from GOG"
    exit 1
fi

cp _publish/* "$rfg_path"
echo "Copied build to $rfg_path"