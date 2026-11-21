param(
  [Parameter(Mandatory = $true)][string]$InputPath,
  [Parameter(Mandatory = $true)][string]$OutputPath
)

$reader = $null
$writer = $null
$skipBrokenProcedure = $false

try {
  $reader = New-Object System.IO.StreamReader($InputPath, [System.Text.Encoding]::UTF8, $true)
  $writer = New-Object System.IO.StreamWriter($OutputPath, $false, [System.Text.UTF8Encoding]::new($false))

  while (($line = $reader.ReadLine()) -ne $null) {
    if ($skipBrokenProcedure) {
      if ($line -cmatch '^CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_PlantillaSuplente_ObtenerTodos`\(\)$') {
        $writer.WriteLine($line)
        $skipBrokenProcedure = $false
      }
      continue
    }

    if ($line -cmatch "GRANT SELECT ON bd_GranET12\.PlantillaTitular TO 'usuario'@'localhost';" -or
        $line -cmatch "ENDGRANT SELECT ON bd_GranET12\.PlantillaTitular TO 'usuario'@'localhost';" -or
        $line -cmatch 'BEGINet_client \*/') {
      continue
    }

    if ($line -cmatch '/\*!50003 DROP PROCEDURE IF EXISTS `sp_PlantillaSuplente_ObtenerTodos` \*/') {
      @(
        '/*!50003 DROP PROCEDURE IF EXISTS `sp_PlantillaSuplente_ObtenerTodos` */;'
        '/*!50003 SET @saved_cs_client      = @@character_set_client */ ;'
        '/*!50003 SET @saved_cs_results     = @@character_set_results */ ;'
        '/*!50003 SET @saved_col_connection = @@collation_connection */ ;'
        '/*!50003 SET character_set_client  = cp850 */ ;'
        '/*!50003 SET character_set_results = cp850 */ ;'
        '/*!50003 SET collation_connection  = cp850_general_ci */ ;'
        'DELIMITER ;;'
      ) | ForEach-Object { $writer.WriteLine($_) }
      $skipBrokenProcedure = $true
      continue
    }

    $writer.WriteLine($line)
  }
}
catch {
  Write-Error "No se pudo limpiar el dump: $_"
  exit 1
}
finally {
  if ($reader) { $reader.Dispose() }
  if ($writer) { $writer.Dispose() }
}
