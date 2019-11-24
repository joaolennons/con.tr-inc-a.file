cd backend/src/api/
dotnet publish --output="../../../dist/backend"
cd ../../../dist
start dotnet api.dll

cd ../frontend/costela

npm install && ng s --open