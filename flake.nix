{
  description = "DevShell for F#";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-24.05";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs { inherit system; };
      in {
        devShells.default = pkgs.mkShell {
          packages = with pkgs; [ dotnet-sdk_9 go-task ];

          shellHook = ''
            export DOTNET_ROOT=${pkgs.dotnet-sdk_9}
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

