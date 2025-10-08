# BSA Browser CLI

This is a CLI program to interact with BSA/BA2 archives, created by request.

# Version GTK (net8.0) for compatibiliy Linux, Window, MAC...
by N3oRay

Compilation OK with Dotnet - Test in progress

# For Window ---------------------------------------
1 - Install .NET SDK (for example with the command: 
winget install --id=Microsoft.DotNet.Runtime.8 -e;
winget install --id=Microsoft.DotNet.SDK.8  -e;

# For linux -----------------------

1 - Install .NET SDK (for example with the command: 
`sudo apt install dotnet-sdk-8.0`

(or by following the official .NET documentation).
2 - Clone the deposit: 
`git clone https://github.com/N3oRay/BSA_Browser.git`
3 - Access the main project file (for according to the version to be compiled).
`cd "BSA Browser CLI"`
4 - Launch the compilation with: 
`dotnet build`
5 - Publish: 
`dotnet publish`


Currently, only "BSA Browser CLI" works on Linux via the command line.

I am currently working on "BSA Browser" to have a multi-Platfrom project.

# Commande -------------
-- Sample extraction and overite

    ./BSA\ Browser\ CLI bluearchmage.bsa -e -o .
    
-- Sample extraction and overite

    ./BSA\ Browser\ CLI archiveSkyrim.bsa -e -o .
Extracting: 12/12 - textures/clothes/warrior/m/robe_n.dds

    ./BSA\ Browser\ CLI archiveSkyrim.bsa --noheaders -e -o .
Extracting: 12/12 - textures/clothes/archmage/m/robe_n.dds

    ./BSA\ Browser\ CLI archiveFallout4.bsa --mtc -e -o .
Extracting: 12/12 - textures/clothes/cyber/m/robe_n.dds

    ./BSA\ Browser\ CLI archiveSkyrim.bsa  -e -o .
Extracting: 12/12 - textures/clothes/mage/m/robe_n.dds

# Command List -------------
    ./BSA\ Browser\ CLI bluearchmage.bsa  -l
    textures/clothes/archmage/f/boots.dds
    textures/clothes/archmage/f/boots_n.dds
    textures/clothes/archmage/f/hood.dds
    textures/clothes/archmage/f/hood_n.dds
    textures/clothes/archmage/f/robes.dds
    textures/clothes/archmage/f/robes_n.dds
    textures/clothes/archmage/m/boots.dds
    textures/clothes/archmage/m/boots_n.dds
    textures/clothes/archmage/m/hood.dds
    textures/clothes/archmage/m/hood_n.dds
    textures/clothes/archmage/m/robe.dds
    textures/clothes/archmage/m/robe_n.dds


# ----------- Notice --------------

    BSA Browser CLI - 1.0.0
    Extract or list files inside .bsa and .ba2 archives.
    
    bsab [OPTIONS] FILE [FILE...] [DESTINATION]
    
      -h, --help             Display this help page
      -i                     Ignore errors with opening archives or extracting files
      -e:[OPTIONS]           Extract files
         options               N   Extract files directly into destination, without directories
      -l:[OPTIONS]           List files
         options               A   Prepend each line with archive filename
                               F   Prepend each line with full archive file path
                               N   Display filename only
                               S   Display file size (bytes)
                               X   Display file size (humanize)
      -o, --overwrite        Overwrite existing files
      -f FILTER              Simple filtering. Wildcard supported. Case-insensitive
      --exclude FILTER       Exclude using simple filtering. Wildcard supported. Case-insensitive
      --regex REGEX          Regex filtering. Case-sensitive
      --encoding ENCODING    Set encoding to use
         encodings             utf8     (Default)
                               system   Use system default encoding
                               ascii
                               unicode
                               utf32
                               utf8
      --noheaders            Extract unsupported textures without DDS header instead of skipping
      --mtc                  Match time changed on extracted files with archive
    
    Multiple filters can be defined and mixed. Filters are matched from first to last.


# --- Installaton de .NET

Pour vérifier la version du SDK installée, exécuter dans un terminal:

    dotnet --list-sdks

Le résultat doit être similaire à:

    8.0.119 [/usr/lib/dotnet/sdk] or 8.0.112 [/usr/lib/dotnet/sdk]
