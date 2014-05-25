pvc.Task("nuget-push", () => {
	pvc.Source("src/Pvc.Less.csproj")
	   .Pipe(new PvcNuGetPack(
			createSymbolsPackage: true
	   ))
	   .Pipe(new PvcNuGetPush());
});