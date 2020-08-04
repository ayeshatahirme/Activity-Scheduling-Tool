Pseudo code

# INPUTS:
SUBNAME, CHRS, SUBTYPE, T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7
Maximum M_SUBJECT 8
Algorithm:
Structure SUBJECT
{
 SUBNAME
 CHRS
 SUBTYPE
}
Structure TIMETABLE
{
  T_ID
 LEC1
 LEC2
 LEC3
 LEC4
TBREAK
 LEC5
 LEC6
 LEC7
}
SLOT_ALLOCATION (SUBJECT S[ ], TIMETABLE T [ ] , M_SUBJECT)
{   
   Let  WEEKDAY = 1
        For i=1 to M_SUBJECT
      {  
             If ( i=1 | | i =3 || i =5 || i =7  )
           {
               if (S[ i ].SUBTYPE == "Lab" || S[ i ].SUBTYPE == "lab" || S[ i ].SUBTYPE == "l")
            {
                T[ WEEKDAY ].LEC1=S[ i ].SUBNAME
                T[ WEEKDAY ].LEC2=S[ i ].SUBNAME
                T[ WEEKDAY ].LEC3=S[ i ].SUBNAME
            }
            else if(S[ i ].SUBTYPE =="Theory" || S[ i ].SUBTYPE == "theory" || S[ i ].SUBTYPE == "th")
            {
                if(S[ i ].CHRS=="1")
                {
                T[ WEEKDAY ].LEC1=S[ i ].SUBNAME
                T[ WEEKDAY ].LEC2= “ – ”
                T[ WEEKDAY ].LEC3= “ – ”
                }
                else if(S[ i ].CHRS =="2")
                {
                T[ WEEKDAY ].LEC1=S[ i ].SUBNAME
                T[ WEEKDAY ].LEC2=S[ i ].SUBNAME
                T[ WEEKDAY ].LEC3= “ – ” 
                }
                else if(S[ i ].CHRS =="3")
                {
                    T[ WEEKDAY ].LEC1=S[ i ].SUBNAME
                    T[ WEEKDAY  ].LEC2=S[ i ].SUBNAME
                    T[ WEEKDAY  ].LEC3=S[ i ].SUBNAME  
                }
            }
            Else 
            {
                T[ WEEKDAY  ].LEC1= “ – ” 
                T[ WEEKDAY  ].LEC2= “ – ” 
                T[ WEEKDAY  ].LEC3= “ – ” 
            }
         }
         If ( i =2 || i =4 || i =6 || i =8)    
         {
              if (S[ i ].SUBTYPE == "Lab" || S[ i ].SUBTYPE == "lab" || S[ i ].SUBTYPE == "l")  
            {
                    T[ WEEKDAY  ].LEC4= “ – ”    
                    T[ WEEKDAY  ].TBREAK = “BREAK” 
                    T[ WEEKDAY  ].LEC5=S[ i ].SUBNAME
                     T[ WEEKDAY  ].LEC6=S[ i ].SUBNAME
                     T[ WEEKDAY  ].LEC7=S[ i ].SUBNAME
            }
           else if((S[ i ].SUBTYPE == "Theory" || S[ i ].SUBTYPE == "theory" || S[ i ].SUBTYPE == "th") && 
           (S[ i – 1 ].SUBTYPE == "Theory" || S[ i – 1 ].SUBTYPE == "theory" || S[ i – 1 ].SUBTYPE == "th") && 
            (S[ i - 1 ].CHRS || S[ i – 1 ].CHRS == "2" || S[ i – 1 ].CHRS == "3")) 
            {
                if (S[ i ].CHRS == "1")  
                {
                     T[ WEEKDAY  ].LEC4=S[ i ].SUBNAME
                    T[ WEEKDAY  ].TBREAK = “BREAK” 
                    T[ WEEKDAY  ].LEC5= “ – ”
                    T[ WEEKDAY  ].LEC6= “ – ”
                    T[ WEEKDAY  ].LEC7= “ – ” 
                 }
                else if (S[ i ].CHRS == "2")
                {
                     T[ WEEKDAY  ].LEC4=S[ i ].SUBNAME
                    T[ WEEKDAY  ].TBREAK = “BREAK”     
                    T[ WEEKDAY  ].LEC5= S[ i ].SUBNAME
                    T[ WEEKDAY  ].LEC6= “ – ”                    
                    T[ WEEKDAY  ].LEC7= “ – ”                    
                }
                else if (S[ i ].CHRS == "3")     
                {
                     T[ WEEKDAY  ].LEC4=S[ i ].SUBNAME 
                    T[ WEEKDAY  ].TBREAK = “BREAK” 
                    T[ WEEKDAY  ].LEC5= S[ i ].SUBNAME 
                    T[ WEEKDAY  ].LEC6= S[ i ].SUBNAME 
                    T[ WEEKDAY  ].LEC7= “ – ”                     
                }
            }
            else if ((S[ i ].SUBTYPE == "Theory" || S[ i ].SUBTYPE == "theory" || S[ i ].SUBTYPE == "th") &&
           (S[ i  - 1 ].SUBTYPE == "Lab" || S[ i – 1 ].SUBTYPE == "lab" || S[ i – 1 ].SUBTYPE == "l"))
            {
                if (S[ i ].CHRS == "1")  
                {
                    T[ WEEKDAY  ].LEC4=S[ i ].SUBNAME 
                    T[ WEEKDAY  ].TBREAK = “BREAK”     
                    T[ WEEKDAY  ].LEC5= “ – ”                    
                    T[ WEEKDAY  ].LEC6= “ – ”
                    T[ WEEKDAY  ].LEC7= “ – ” 
                }
                else if (S[ i ].CHRS == "2")  
                {
                    T[ WEEKDAY  ].LEC4=S[ i ].SUBNAME  
                    T[ WEEKDAY  ].TBREAK = “BREAK”      
                    T[ WEEKDAY  ].LEC5= S[ i ].SUBNAME 
                    T[ WEEKDAY  ].LEC6= “ – ”                     
                    T[ WEEKDAY  ].LEC7= “ – ”                     
                }
                else if (S[ i ].CHRS == "3")                  
                {
                    T[ WEEKDAY  ].LEC4=S[ i ].SUBNAME     
                    T[ WEEKDAY  ].TBREAK = “BREAK”         
                    T[ WEEKDAY  ].LEC5= S[ i ].SUBNAME    
                    T[ WEEKDAY  ].LEC6= S[ i ].SUBNAME    
                    T[ WEEKDAY  ].LEC7= “ – ”                        
                }
            }
            Else           
            {
                    T[ WEEKDAY  ].LEC4=“ – ” 
                    T[ WEEKDAY  ].TBREAK = “BREAK” 
                    T[ WEEKDAY  ].LEC5= “ – ”               
                    T[ WEEKDAY  ].LEC6= “ – ”               
                    T[ WEEKDAY  ].LEC7= “ – ”               
            }
              WEEKDAY = WEEKDAY+ 1
         }
    }
}

