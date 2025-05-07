{
  description = "DevShell for F#";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/52d0eded529af34e91df6b2a2bc32eb636637cd2";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs { inherit system; };
      in {
        devShells.default = pkgs.mkShell {
          packages = [ pkgs.dotnet-sdk_8 pkgs.go-task ];

          shellHook = ''
            export DOTNET_ROOT=$(dirname $(readlink -f $(which dotnet)))
            if [ ! -f .config/dotnet-tools.json ]; then
              dotnet new tool-manifest
              dotnet tool install fantomas
              dotnet tool install dotnet-fsharplint
            else
              dotnet tool restore
            fi
          '';
        };
      });
}

