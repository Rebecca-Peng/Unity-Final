using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO.Ports;
using System.Threading;

public class PlayerSerialRead : MonoBehaviour {

	double mAccelCurrent;
	double mAccelLast;
	public double frequency;
	float addF;
	float speed;
	//	public bool fly;

	int state0 = 0;
	int state1 = 0;

	int count = 0;
	int pastpeak = 0;
	int curpeak = 0;
	int diff = 0;
	int diff2 = 0;
	int pastdiff = 0;

	[Range(1.0f,5.0f)]
	public float max;
	[Range(0.0f,1.0f)]
	public float min;

	[Range(80f,250f)]
	public float threshold;

	[Range(0f,500f)]
	public int gap;

	private SerialPort serialPort = null;
	private string portName = "/dev/cu.HC-05-DevB";
	private int baudRate = 9600;
	private int readTimeOut = 100;

	private string serialInput;

	bool programActive = true;
	Thread thread;

	// Use this for initialization
	void Start () {
		max = 1.3f;
		min = 0.95f;
		gap = 150;
		threshold = 171f;
//		count = 0;
//		addForce = 0;

		try
		{
			serialPort = new SerialPort();
			serialPort.PortName = portName;
			serialPort.BaudRate = baudRate;
			serialPort.ReadTimeout = readTimeOut;
			serialPort.Open();
		}
		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
		thread = new Thread(new ThreadStart(ProcessData));
		thread.Start();
	}

	void ProcessData()
	{
		Debug.Log("Thread: Start");
		while (programActive)
		{
			try
			{
				serialInput = serialPort.ReadLine();
			}
			catch (TimeoutException)
			{

			}
		}
		Debug.Log("Thread: Stop");
	}

	// Update is called once per frame
	void Update () {
		
		if (serialInput != null) {
			string[] vec3 = serialInput.Split (',');
			if (vec3.Length > 2) {
				int X = int.Parse(vec3 [0]);
				int Y = int.Parse(vec3 [1]);
				int Z = int.Parse(vec3 [2]);
				//				Debug.Log (X + "," + Y + "," + Z);


//				count ++;
				state0 = state1;

				mAccelLast = mAccelCurrent;
				mAccelCurrent = Mathf.Sqrt(Mathf.Sqrt (Mathf.Abs(X * X + Y * Y + Z * Z)));

				if (mAccelCurrent > max * mAccelLast) {
					state1 = 1;
				} else if (mAccelCurrent <= max * mAccelLast && mAccelCurrent > min * mAccelLast) {
					state1 = 0;
				} else {
					state1 = -1;
				}

				if (state0 != state1 && state1 == 1) {
					//					Debug.Log (mAccelCurrent);
					frequency = mAccelCurrent;
					//					pastpeak = curpeak;
					//					curpeak = count;
					//					pastdiff = diff;
					//					diff = curpeak - pastpeak;
				}
				else frequency = mAccelLast;


				if (frequency > threshold) {
					addF++;
				}
//				else {
//					addF --;
//				}
//				Debug.Log (frequency);

				if (addF >= gap) {
					addF = 0;
				}
				speed = addF ;

			}
		}
//		Debug (mAccelCurrent);
//		Debug.Log (addF);	
	}
}
