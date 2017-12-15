#include<Wire.h>
const int MPU_addr=0x68;  // I2C address of the MPU-6050

int16_t AcX,AcY,AcZ,Tmp,GyX,GyY,GyZ;

double mAccelCurrent;
  double mAccelLast;
  float frequency;

  int state0 = 0;
  int state1 = 0;

  int count = 0;
  int pastpeak = 0;
  int curpeak = 0;
  int diff = 0;
  int diff2 = 0;
  int pastdiff = 0;


void setup(){
  Wire.begin();
  Wire.beginTransmission(MPU_addr);
  Wire.write(0x6B);  // PWR_MGMT_1 register
  Wire.write(0);     // set to zero (wakes up the MPU-6050)
  Wire.endTransmission(true);
  Serial.begin(9600);
//  Serial.println("test");
}

void loop(){
   read_mpu_6050_data(); 
   senseMove();
  }
void read_mpu_6050_data(){
  Wire.beginTransmission(MPU_addr);
  Wire.write(0x3B);  // starting with register 0x3B (ACCEL_XOUT_H)
  Wire.endTransmission(false);
  Wire.requestFrom(MPU_addr,14,true);  // request a total of 14 registers
  AcX=Wire.read()<<8|Wire.read();  // 0x3B (ACCEL_XOUT_H) & 0x3C (ACCEL_XOUT_L)     
  AcY=Wire.read()<<8|Wire.read();  // 0x3D (ACCEL_YOUT_H) & 0x3E (ACCEL_YOUT_L)
  AcZ=Wire.read()<<8|Wire.read();  // 0x3F (ACCEL_ZOUT_H) & 0x40 (ACCEL_ZOUT_L)
  Tmp=Wire.read()<<8|Wire.read();
  GyX=Wire.read()<<8|Wire.read(); 
  GyY=Wire.read()<<8|Wire.read();
  GyZ=Wire.read()<<8|Wire.read();  // 0x47 (GYRO_ZOUT_H) & 0x48 (GYRO_ZOUT_L)
}

void senseMove(){
    Serial.print(AcX);
    Serial.print(",");
    Serial.print(AcY);
    Serial.print(",");
    Serial.println(AcZ);

//  count++;
//  state0 = state1;
//
//  mAccelLast = mAccelCurrent;
//  mAccelCurrent = sqrt (abs(AcX * AcX + AcY * AcY + AcZ * AcZ));
//
//  if (mAccelCurrent > 1.068 * mAccelLast) {
//          state1 = 1;
//        } else if (mAccelCurrent <= 1.068 * mAccelLast && mAccelCurrent > 0.95 * mAccelLast) {
//          state1 = 0;
//        } else {
//          state1 = -1;
//        }
//  if (state0 != state1 && state1 == 1) {
//          pastpeak = curpeak;
//          curpeak = count;
//          pastdiff = diff;
//          diff = curpeak - pastpeak;
//        }
//
//  if(diff>10){
//    diff2 = diff;
//    }
////    else diff2 = 10;
//  Serial.println(diff2);
    
  }


