   M S B A M L   `   `   `  ����  
HomeScreen&     HomeScreen.ImageSliderTestWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  ImageSliderTestWindow��5   	   $
��1920��5   	   $
��1080��6    � WindowStartupLocation$ CenterScreen=�6$    � WindowState$ 	Maximized=�6I    � 
ResizeMode$ NoResize=�6a    � WindowStyle$
 None=�6w    � 	Resources 5       
  FadeIn g� Duration �� TargetProperty W� From		 W� To  FadeOut��%�   &	        &	 h     �� 5	   
   .��5
      W� $ 0:0:.25D�6   $ Opacity�61   $ 0X�6U   $	 1X�6^   5      �� 5   
   .��5      W� $ 0:0:.5D�6   $ Opacity�60   $	 0X�6T   5      5      .��5      �� $
��1024��6   $	��768��6   .+�5   
   �� -   5        
 ��Name$
 myImage��5      $��UniformToFill=�6!    J� RenderTransformOrigin$ 0.5,0.5&�69   $
��1024��6Y   $	��768��6f   z�5      V� 5      .~�5      T�  T� X$ 0Q�6)    T� Y$ 0Q�6/   5      5      �� 5   
   -   5        $
 myImage2��5      $��UniformToFill=�6"   $ 0.5,0.5&�6:   $
��1024��6Z   $	��768��6g   z�5      V� 5      .~�5      T� $ 0Q�6)   $ 0Q�6/   5      5       �� 5!   
   -   5         ��Name$ 	ErrorText��5!   (   $
��Wrap=�6   $��Stretch=�6;   $��Center=�6Y    �� TextAlignment$ Center=�6t   $y�	Collapsed=�6�   $)��#The specified folder does not exist��6�   $��20(�6�   5"      5#      