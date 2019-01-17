package com.example.androidbluetooth;

import android.widget.Toast;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothServerSocket;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;

import java.io.InputStream;
import java.io.OutputStream;
import java.util.Set;
import java.util.UUID;
import java.io.IOException;

import android.os.Bundle;
import android.os.Handler;
import android.os.SystemClock;
import com.unity3d.player.UnityPlayer;

public class MainActivity {

	private static BluetoothAdapter bluetoothAdapter;
	private static UUID MY_UUID_SECURE = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");
	
	private static OutputStream outStream = null;
	private static BluetoothSocket btSocket = null;
	private static BluetoothDevice btdev = null;

	public static BluetoothDevice Search() {
		bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

		Set<BluetoothDevice> pairedDevices = bluetoothAdapter.getBondedDevices();
		if (pairedDevices.size() > 0)
			for (BluetoothDevice device : pairedDevices)
				if (device.getName().equals("BluetoothV3"))
					btdev = device;

		return btdev;
	}

	public static String GetPairAddress() {
		return Search().getAddress();
	}

	public static String GetPairName() {
		return Search().getName();
	}

	public static void openBluetooth() {
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				BluetoothAdapter bluetoothAdapter;
				bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

				if (bluetoothAdapter.isEnabled() == false) {
					bluetoothAdapter.enable();
				}
			}
		});
	}	

	// Method必須為static
	public static void showToast(final String content, final boolean isLong)// 傳入的參入必須為final，才可讓Runnable()內部使用
	{
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				// 若使用者傳入的boolean為true，則Toast顯示3.5秒；否則為2秒
				Toast.makeText(UnityPlayer.currentActivity, content, isLong ? Toast.LENGTH_LONG : Toast.LENGTH_SHORT)
						.show();
			}
		});
	}

	public static void findBT() {
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
				if (bluetoothAdapter.isEnabled() == false) {
					Toast.makeText(UnityPlayer.currentActivity, "TURN ON BLUETOOTH AND RESTART", Toast.LENGTH_LONG)
							.show();
				} else {

//					String address = bluetoothAdapter.getAddress();
//					String name = bluetoothAdapter.getName();
//					Toast.makeText(UnityPlayer.currentActivity, address + name, Toast.LENGTH_LONG).show();

					Toast.makeText(UnityPlayer.currentActivity, "Welcome", Toast.LENGTH_LONG).show();

				}

				Set<BluetoothDevice> pairedDevices = bluetoothAdapter.getBondedDevices();
				if (pairedDevices.size() > 0) {
					for (BluetoothDevice device : pairedDevices) {
						if (device.getName().equals("BluetoothV3")) {
							Toast.makeText(UnityPlayer.currentActivity,
									"Connect to" + device.getName() + " " + device.getAddress(), Toast.LENGTH_LONG)
									.show();
						}
					}
				}
			}
		});

	}

	public static void Write(final byte[] bytes) {

		try {
			outStream = btSocket.getOutputStream();
		} catch (IOException e) {
		}

		try {
			outStream.write(bytes);
		} catch (IOException e) {
		}

	}

	public static void ShowSend() {
		Toast.makeText(UnityPlayer.currentActivity, "Send", Toast.LENGTH_LONG).show();
	}

	public static void Connect(final String btAddress) {
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
				BluetoothDevice device = bluetoothAdapter.getRemoteDevice(btAddress);

				try {
					btSocket = device.createRfcommSocketToServiceRecord(MY_UUID_SECURE);
				} catch (IOException e) {
				}
				bluetoothAdapter.cancelDiscovery();

				try {
					btSocket.connect();
				} catch (IOException e) {
					try {
						btSocket.close();
					} catch (IOException e2) {
					}
				}

				try {
					outStream = btSocket.getOutputStream();
				} catch (IOException e) {
				}

				// Test
				String message = "q";
				byte[] msgBuffer = message.getBytes();

				try {
					outStream.write(msgBuffer);
				} catch (IOException e) {
				}

			}
		});
	}

}