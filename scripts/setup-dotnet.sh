#!/usr/bin/env bash
set -euo pipefail

echo "==> Installing prerequisites"
sudo apt-get update
sudo apt-get install -y wget curl ca-certificates libc6 libgcc-s1 libicu-dev libssl-dev zlib1g

echo "==> Downloading dotnet-install.sh"
curl -fsSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh
chmod +x /tmp/dotnet-install.sh

echo "==> Installing .NET 10 preview SDK"
mkdir -p "$HOME/.dotnet"
/tmp/dotnet-install.sh --channel 10.0 --install-dir "$HOME/.dotnet"

echo "==> Exporting PATH"
{
  echo 'export DOTNET_ROOT="$HOME/.dotnet"'
  echo 'export PATH="$HOME/.dotnet:$HOME/.dotnet/tools:$PATH"'
} >> "$HOME/.bashrc"

export DOTNET_ROOT="$HOME/.dotnet"
export PATH="$HOME/.dotnet:$HOME/.dotnet/tools:$PATH"

echo "==> Verifying installation"
dotnet --info