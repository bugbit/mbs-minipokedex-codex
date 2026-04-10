#!/usr/bin/env bash
set -euo pipefail

DOTNET_ROOT_DIR="${DOTNET_ROOT:-$HOME/.dotnet}"
BASHRC_FILE="$HOME/.bashrc"

echo "==> Installing prerequisites"
sudo apt-get update
sudo apt-get install -y wget curl ca-certificates libc6 libgcc-s1 libicu-dev libssl-dev zlib1g

echo "==> Downloading dotnet-install.sh"
curl -fsSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh
chmod +x /tmp/dotnet-install.sh

echo "==> Installing .NET 10 SDK"
mkdir -p "$DOTNET_ROOT_DIR"
/tmp/dotnet-install.sh --channel 10.0 --install-dir "$DOTNET_ROOT_DIR"

if ! grep -q 'export DOTNET_ROOT=' "$BASHRC_FILE"; then
  {
    echo 'export DOTNET_ROOT="$HOME/.dotnet"'
    echo 'export PATH="$HOME/.dotnet:$HOME/.dotnet/tools:$PATH"'
  } >> "$BASHRC_FILE"
fi

export DOTNET_ROOT="$DOTNET_ROOT_DIR"
export PATH="$DOTNET_ROOT_DIR:$DOTNET_ROOT_DIR/tools:$PATH"

echo "==> Verifying installation"
dotnet --version
dotnet --info
