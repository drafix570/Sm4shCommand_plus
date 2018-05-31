Sm4shCommand_plus
===========
このファイルセットはソースコードです。ソフトウェアを使いたい人はreleaseタブからSm4shCommand_plus.zipをダウンロードしてください。

##Requirements##
- .NET Framework 4.0
- Visual Studio 2015

##変更点##
- **Sm4shCommand**
  - ParseAnimation読込自動化のためのボタンとコマンドを追加。
  - Events.cfgの中身を削除し、SALT.dllの内容が上書きされないように対策。
  - 開いたときのフォームの大きさを前回起動時のウィンドウサイズに設定。

- **SALT**
  -ACMD_INFO.csのラベリング用リストを、最新のSm4sh-ToolsのCMD_INFO.csのものに更新。Nightly版でデデデのgame.binが開けない問題も解決。
  
## ビルド ##
  - Visual Studioで.slnファイルを開き、ビルドしてください。