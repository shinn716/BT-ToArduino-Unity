# Bluetooth(BT)ToArduino-Unity  
  
Previous..(Arduino code and Bt moudle, you can see from here.)  
https://github.com/shinn716/BluetoothToArduino-Processing  
  
<img src="https://github.com/shinn716/AndroidBluetoothToArduino-Unity/blob/master/ezgif.com-optimize.gif" /></a>  
   
Unity use native AndroidBluetooth.jar...  
<img src="https://github.com/shinn716/BluetoothToArduino-Unity/blob/master/Snipaste_2019-01-17_10-34-16.png" /></a>  
Type your bluetooth device name and address.   
<img src="https://github.com/shinn716/AndroidBluetoothToArduino-Unity/blob/master/Snipaste_2019-01-17_14-47-19.png" /></a>  
  
Bluetooth.cs  
```  
/// 設定要抓取藍芽裝置的名稱
public static void SetDevName(string name)
...
/// 設定要抓取藍芽裝置的位址
public static void SetDevAddr(string addr)
...
/// 強制開啟藍芽
public static void openBT()
...
/// Close
public static void closeBt()
...
/// 搜尋藍芽裝置
public static void findBT()
 ...
/// 藍芽連線
public static void Connect(string address)
...
/// 寫入訊號(byte), 專案用於Arduino Serial Read 'q', 'w', 'e'三種訊號
public static void Write(byte[] bytes)
...
/// 抓取配對裝置的位址
public static string GetPairAddress()
...
/// 抓取配對裝置的名稱
public static string GetPairName()
...
/// 顯示 Toast, 可傳入自訂的字串
public static void ShowSend(string info)
...
```  
  
jar (You can modified jar from MainActivity.java)  
<img src="https://github.com/shinn716/BluetoothToArduino-Unity/blob/master/Snipaste_2019-01-17_10-33-23.png" /></a>  
  
Reference   
------------
 - Unity 使用Android Bluetooth (Eclipse)  
http://oblivious9.pixnet.net/blog/post/95640112-unity-%E4%BD%BF%E7%94%A8android-bluetooth-%28eclipse%29  

 - Eclipse Export Jar  
http://xken831.pixnet.net/blog/post/434389295-%5Bjava%5D%5Beclipse%5D-eclipse-%E6%89%93%E5%8C%85%E5%BB%BA%E7%AB%8B-jar-%E6%AA%94  

 - OutputStream  
https://www.javaworld.com.tw/jute/post/view?bid=26&id=275260  
  
 - Eclipse develope Android  
http://readandplay.pixnet.net/blog/post/140001110-%E7%AC%AC%E4%B8%80%E6%94%AFandroid-app%E7%A8%8B%E5%BC%8F%E6%95%99%E5%AD%B8  
