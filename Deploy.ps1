# Path of the TEST environment
$path = "C:\inetpubdirectto\api-marketplace-test"

# Stop IIS
$stop = Read-Host -Prompt "Please stop IIS service, make sure to backup files, then press enter..."

# Get version
$version = Read-Host -Prompt "Enter version in format vx.x.x:"

# Get files from AWS bucket
echo "Downloding from AWS..."
$s3 = "s3://backup.marketplace.directto.io/" + $version + ".zip"
$dest = $version + ".zip"
aws s3 cp $s3 $dest

# Remove older files
echo "Removing older files..."
$remove = $path + "\*"
Remove-Item -path $remove -Recurse -Force

# Unzip files
Expand-Archive $dest -DestinationPath $path -Force

# Copy config files
echo "Copying config and files..."
$pathConfig = "C:\Users\Administrator\Documents\API\TEST\Configs\*"
Copy-Item -Path $pathConfig -Destination $path -Recurse -Force

# Copy Archives
$pathArchive = "C:\Users\Administrator\Documents\API\TEST\Arquivos\*"
Copy-Item -Path $pathArchive -Destination $path -Recurse -Force

# Clean up
Remove-Item -path $dest
echo "Please refresh and start IIS service and you are good to go!"