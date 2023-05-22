!define PRODUCT_NAME "YourProductNameHere"

Name "${PRODUCT_NAME}"
OutFile "WebWrapperSetup.exe"
Icon "default.ico"
BrandingText " "
SilentInstall silent

Section

  SetOutPath "$TEMP\${PRODUCT_NAME}"

  ; Add all files that your installer needs here
  File "setup.exe"
  File "WebWrapperSetup.msi"

  ExecWait "$TEMP\${PRODUCT_NAME}\setup.exe"
  RMDir /r /REBOOTOK "$TEMP\${PRODUCT_NAME}"

SectionEnd