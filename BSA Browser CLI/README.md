# BSA Browser CLI

This is a CLI program to interact with BSA/BA2 archives, created by request.

# Version GTK (net8.0) for compatibiliy Linux, Window, MAC...
by N3oRay

Compilation OK with Dotnet - Test in progress

# For linux -----------------------


    1 - Installer .NET SDK (par exemple avec la commande :
        #sudo apt install dotnet-sdk-8.0
        (ou en suivant la documentation officielle de .NET).
    2 - Cloner le dépôt :
        #git clone https://github.com/N3oRay/BSA_Browser.git
    3 - Accéder au dossier du projet principal (par exemple cd "BSA Browser" ou cd "BSA Browser CLI" selon la version à compiler).
    4 - Lancer la compilation avec :
        #dotnet build
    5 - Publish :
        #dotnet publish

# Commande -------------
-- Sample extraction and overite

    ./BSA\ Browser\ CLI bluearchmage.bsa -e -o .

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
