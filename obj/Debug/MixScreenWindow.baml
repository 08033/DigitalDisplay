   M S B A M L   `   `   `  ����  
HomeScreen     HomeScreen.MixScreenWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  MixScreenWindow��5   	    � Icon$ mirror-product.ico��5   	   $
��1920��5   	   $
��1080��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�6!    � WindowStyle$
 None=�67    � 	Resources 5
       
  FadeIn g� Duration �� TargetProperty	 W� From	
 W� To  FadeOut��%�   &	        &	 h     �� 5   
   .��5      W� $ 0:0:.25D�6   $ Opacity�61   $	 0X�6U   $
 1X�6^   5      �� 5   
   .��5      W� $ 0:0:.5D�6   $ Opacity�60   $
 0X�6T   5      5      .��5      � -   5         �Name$ myGrid��5       � RowDefinitions 5   
   �� 5      $	��10* �6   6+   �� 5      $��5* �6   6*   �� 5      $	��40* �6   6+   �� 5      $	��40* �6   6+   �� 5      $��5* �6   6*    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5#   
   �� -   5         ��Name$ myHeaderImage��5#      $��0��6   $
��Fill=�64   6E   �� 5%   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $
��Left=�6V   $��20 0 0 0q�6q   .+�5&      �� -   5        $��
myDateTime��5&      $��20(�6&   $��Light"�64   .��6G   10 Jan6O   5'      �� 5(   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��Right=�6V   $��0 0 20 0q�6r   .+�5)      �� -   5        $��lblLocation��5)      $��20(�6'   $��Center=�65   $��Light"�6P   $��0 0 -5 0q�6c   .��6u   	Karachi6~   �� 5*      -   5        $��imgWeatherConditions��5*      $��50��60   $��50��6<   $��Center=�6G   $
��Fill=�6b   $-��'http://openweathermap.org/img/w/01d.png��6q   6�   �� 5+      -   5        $��lblTemperature��5+      $��Center=�6*   $��20(�6E   $��Light"�6S   $��-5 0 0 0q�6f   .��6x   7°c6}   �� 5,      -   5        $��lblConditions��5,      $	��Top=�6)   $��15(�6A   $��Light"�6O   .��6b   Sunny6i   5-      r� 5/   
   -	   5        $��myVideoControl��5/      $��2��6-    r� Stretch$
 Fill=�6:   $��20 20 20 20q�6I   6`   �� 53      -
   5        $ myImage��53   6   $��3��6   $��20 20 20 20q�6!   $
��Fill=�6G   59      �� 5:      -   5        $ myImage2��5:   6   $��3��6   $��20 20 20 20q�6!   $
��Fill=�6H   5@      �� 5A      -   5         ��Name$ 	ErrorText��5A   :   $��3��6   $
��Wrap=�6&   $��Stretch=�6M   $��Center=�6k    �� TextAlignment$ Center=�6�   $y�	Collapsed=�6�   $)��#The specified folder does not exist��6�   $��20(�6�   �� 5D   
   
�������$
��Auto��6#   $��2��60   $��4��5E      $	��Top=�6   68   �� 5G   
   $��4��6   
�������.+�5H      �� -   5        $��myTicker��5H   )   $��0 5 0 0q�6   $��20(�69   $��Light"�6G   $��Sample Marquee��6Z   5I      5J      5K      