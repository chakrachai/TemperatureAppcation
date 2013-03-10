
#include <OneWire.h>
int Port_D3 = 13;
int Port_D2 = 12;
int Port_D1 = 11;
int Port_D0 = 10;

int incomingByte,ID_Name;
int SensorPin = 2; 
OneWire ds(SensorPin); 
#include "OneWire.C"

void setup(void) 
{  
  pinMode(Port_D3, INPUT);     // initialize the digital pin as an input  
  pinMode(Port_D2, INPUT);     // initialize the digital pin as an input  
  pinMode(Port_D1, INPUT);     // initialize the digital pin as an input  
  pinMode(Port_D0, INPUT);     // initialize the digital pin as an input  
  Serial.begin(9600);
}

void loop(void) 
{  
  if (Serial.available()>0)
  { 
    if(digitalRead(Port_D3)==LOW)  ID_Name='1';   
    if(digitalRead(Port_D2)==LOW)  ID_Name='2';   
    if(digitalRead(Port_D1)==LOW)  ID_Name='3';   
    if(digitalRead(Port_D0)==LOW)  ID_Name='4';   
    
    incomingByte = Serial.read();       // read the incoming byte: 
    if(incomingByte==ID_Name)  
    {  
      float temp = getTemp();
      Serial.print("ID_");
      Serial.write(ID_Name);
      Serial.print("=");
      Serial.println(temp,4);  // 4 Digit Print
    }
  } 
}




