echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
echo 'export PATH=$DOTNET_ROOT:$DOTNET_ROOT/tools:$PATH' >> ~/.bashrc
source ~/.bashrc
dotnet --version