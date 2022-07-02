# やること
- Chrome
    - ```$Path = $env:TEMP; $Installer = "chrome_installer.exe"; Invoke-WebRequest "https://dl.google.com/tag/s/appguid%3D%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D%26browser%3D0%26usagestats%3D1%26appname%3DGoogle%2520Chrome%26needsadmin%3Dprefers%26brand%3DGTPM/update2/installers/ChromeSetup.exe" -OutFile $Path\$Installer; Start-Process -FilePath $Path\$Installer -Args "/silent /install" -Verb RunAs -Wait; Remove-Item $Path\$Installer``` 
 

- Unityのダウンロード
    - UnityHub: https://unity3d.com/jp/get-unity/download 
    - UnityHubで2021.3.5f1 

- install visual studio code
    - install: https://code.visualstudio.com/ 

- dockerをやる (下のどちらか)
    - install rancher desktop: https://docs.rancherdesktop.io/getting-started/installation/
    - install docker desktop: https://docs.docker.com/desktop/windows/install/ 

- Gitをやる
    - install: https://prog-8.com/docs/git-env-win 
        - git for widows: https://gitforwindows.org/  
        - 全てデフォルトのままでいいんでない？ 
    - GitHubのアカウント登録 
        - Username: 
        - Password: 
        - Email
    - Gitを試す(Git BashとWindowsで計測)
        - config設定 
            - git config --global user.name "name" 
            - git config --global user.email "email@email"

- Dockerをやる  
    - ホームページを立てる? 

- Goのダウンロード
    - 








