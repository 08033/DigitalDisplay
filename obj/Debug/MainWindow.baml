   M S B A M L   `   `   `  ����  
HomeScreen    HomeScreen.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Wall Mirror��5   	    � Icon$ mirror-product.ico��6   $
��1920��5   	   $
��1080��6    � WindowStartupLocation$ CenterScreen=�6$    � WindowState$ 	Maximized=�6I    � 
ResizeMode$ NoResize=�6a    � WindowStyle$
 None=�6w    � 	Resources 5         tbStyle1 �� 
TargetType �� Property	 �� Value��%T   &	        �� 5   
   " ��6!   .�5      ��  � ��
	 �   �6+   5	      5
      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    5   
    �� BasedOn��%0   '��       7   �� 5      8   " ��68   6Z   5      ��5   
   �� 5       �� ImageSource$ mirror-product.jpg��6    j� Stretch$ UniformToFill=�6:   .+�5   
   �� $��0��6   $��0��6!   $
��Left=�61   $	��Top=�6L    �� Padding$ 15q�6d   $��34(�6q   Good Morning,�� 5      6(   �� 64   $��24(�6:   $
��Left=�6H   
�������.��6u   User6{   5      �� 5   
   $��0��6   $��1��6"   .+�5       �� -   5        $��lblLocation��5    1   $��Right=�6   $��34(�6D   $��15q�6R   .��6_   	Karachi6h   �� 5!       �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5"      �� -   5        $��lblTemperature��5"      $��24(�6.   $��Center=�6<   
�������.��6i   7°c6n   �� 5#      -   5        $��lblConditions��5#      $��24(�6-   $��Center=�6;   
�������.��6h   Sunny6o   �� 5$      -   5        $��imgWeatherConditions��5$      $
��None=�64   $-��'http://openweathermap.org/img/w/01d.png��6C   6v   5%      5&      �� 5(   
   -   5         ��Name$ myImage��5(   1   $��1��6   $��2��6   $��bin/debug/Images/1.jpg��6B   $
��Fill=�6b   $
��Auto��6q   $	��275��6~   $��Center=�6�   $��2��6�   6�   �� 5*   
   $��2��6   $��0��6!   $
��Left=�61   $��Bottom=�6L   $ 15q�6g   $��34(�6t   �� 5+      -   5        $��lblDate��5+      .��6#   Sat, Jan 24th62   �� 5,      �� 5-      -   5        $��lblTime��5-   4   $��24(�6   
�������.��6C   	8:30 am5.      5/      r� 51   
   -	   5        $��VideoControl��51      $��2��6+   $��1��68   $
��Auto��6H   $	��400��6U   $��Center=�6b   $��0 0 15 0q�6}    r� Source$3 -C:\Users\Mohammad\Downloads\2-Video\piper.mp4?�52      6P   55      56      