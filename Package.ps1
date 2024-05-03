# Get version
$version = Read-Host -Prompt "Enter version in format vx.x.x:"

# Publish path
$path = "C:\Publicar\Directto_API"

# Remove older files
echo "Removing older files..."
if (Test-Path $path) {
  Remove-Item -path $path -recurse 
}

# Build and publish to directory
echo "Building project..."
MSBUILD /p:DeployOnBuild=true /p:PublishProfile=StartadoraAPI

# Exclusions
$exclude = @("Web.config","Secrets.config","Database.config", "log4net.config")

# Get files with exclusions
$files = Get-ChildItem -Path $path -Exclude $exclude

# Generate zip
echo "Packaging files..."
$package = $path + "\" +  $version + ".zip"
Compress-Archive -Path $files -DestinationPath $package -CompressionLevel Fastest

# Publish to AWS bucket
echo "Publishing to AWS..."
aws s3 cp $package s3://backup.marketplace.directto.io