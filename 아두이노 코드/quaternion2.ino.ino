#include <WiFi.h>
#include <HTTPClient.h>
#include "MPU6050_6Axis_MotionApps20.h"
#include "MPU6050.h"
#include "I2Cdev.h"

#include <Wire.h> //*mpu

#define OUTPUT_READABLE_QUATERNION
#define OUTPUT_READABLE_EULER

MPU6050 mpu;  

#define INTERRUPT_PIN 2

const char WIFI_SSID[] = "Galaxy S20+ 5G6410";
const char WIFI_PASSWORD[] = "12344321";

String HOST_NAME = "http://43.200.102.24";  // change to your PC's IP address
String PATH_NAME = "/insert_temp2.php";

bool dmpReady = false;  // set true if DMP init was successful
uint8_t mpuIntStatus;   // holds actual interrupt status byte from MPU
uint8_t devStatus;      // return status after each device operation (0 = success, !0 = error)
uint16_t packetSize;    // expected DMP packet size (default is 42 bytes)
uint16_t fifoCount;     // count of all bytes currently in FIFO
uint8_t fifoBuffer[64]; // FIFO storage buffer

// orientation/motion vars
Quaternion q;           // [w, x, y, z]         quaternion container
VectorInt16 aa;         // [x, y, z]            accel sensor measurements
VectorInt16 aaReal;     // [x, y, z]            gravity-free accel sensor measurements
VectorInt16 aaWorld;    // [x, y, z]            world-frame accel sensor measurements
VectorFloat gravity;    // [x, y, z]            gravity vector
float euler[3];         // [psi, theta, phi]    Euler angle container
float ypr[3];           // [yaw, pitch, roll]   yaw/pitch/roll container and gravity vector

float Q_W2;
float Q_X2;
float Q_Y2;
float Q_Z2;

// packet structure for InvenSense teapot demo
uint8_t teapotPacket[14] = { '$', 0x02, 0,0, 0,0, 0,0, 0,0, 0x00, 0x00, '\r', '\n' };

volatile bool mpuInterrupt = false;     // indicates whether MPU interrupt pin has gone high
void dmpDataReady() {
    mpuInterrupt = true;
}


void setup() {
  
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.println("Connecting");
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.print("Connected to WiFi network with IP Address: ");
  Serial.println(WiFi.localIP());

    Wire.begin();
    Wire.setClock(400000);
    Serial.begin(115200);  

  mpu.initialize();
  pinMode(INTERRUPT_PIN, INPUT_PULLUP);
  devStatus = mpu.dmpInitialize();

  //mpu.setXAccelOffset(-4146);
  //mpu.setYAccelOffset(1744);
  //mpu.setZAccelOffset(1341);
  mpu.setXGyroOffset(164); //++
  mpu.setYGyroOffset(-36); //--
  mpu.setZGyroOffset(-81);
  

    if (devStatus == 0) {
        mpu.CalibrateAccel(6);
        mpu.CalibrateGyro(6);
        mpu.PrintActiveOffsets();

        Serial.println(F("Enabling DMP..."));
        mpu.setDMPEnabled(true);

        Serial.print(F("Enabling interrupt detection (Arduino external interrupt "));
        Serial.print(digitalPinToInterrupt(INTERRUPT_PIN));
        Serial.println(F(")..."));
        attachInterrupt(digitalPinToInterrupt(INTERRUPT_PIN), dmpDataReady, RISING);
        mpuIntStatus = mpu.getIntStatus();
        
        Serial.println(F("DMP ready! Waiting for first interrupt..."));
        dmpReady = true;

        packetSize = mpu.dmpGetFIFOPacketSize();
    } else {
        Serial.print(F("DMP Initialization failed (code "));
        Serial.print(devStatus);
        Serial.println(F(")"));
    }
}

void loop() {

  if (mpu.dmpGetCurrentFIFOPacket(fifoBuffer)) 
  {
      mpu.dmpGetQuaternion(&q, fifoBuffer);
        
      mpu.dmpGetEuler(ypr, &q);

      Q_W2 = q.w;

      Q_X2 = (ypr[0] * 180/M_PI);
      Q_Y2 = (ypr[1] * 180/M_PI);
      Q_Z2 = (ypr[2] * 180/M_PI);

      String queryString = String ("?Q_W2=") + String(Q_W2)
                     + String ("&Q_X2=") + String(Q_X2)
                     + String ("&Q_Y2=") + String(Q_Y2)
                     + String ("&Q_Z2=") + String(Q_Z2);


  HTTPClient http;

  http.begin(HOST_NAME + PATH_NAME + queryString);  //HTTP

  int httpCode = http.GET();

  // httpCode will be negative on error
  if (httpCode > 0) 
  {
    if (httpCode == HTTP_CODE_OK) 
    {
         String payload = http.getString();
         Serial.println(payload);
    } 
    else 
    {
         Serial.printf("[HTTP] GET... code: %d\n", httpCode);
    }
  } 
  else 
  {
      Serial.printf("[HTTP] GET... failed, error: %s\n", http.errorToString(httpCode).c_str());
  }

  delay(50);

  http.end();
 }
}
