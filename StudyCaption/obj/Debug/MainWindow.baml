   M S B A M L   `   `   `  ����G  CStudyCaption, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:StudyCaptionStudyCaption  5   	       StudyCaption.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:StudyCaption     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� 
���   �6   r� 5   
   -   5        $��Player��5      $��0��6%   64   �� 5   
   -   5        $��CaptionText��5       �� TextAlignment$ Center=�6'   $��35(�6>   
�������$
��Wrap=�6_   $��Bottom=�6s   $��10q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 0Q�6#      Color$ 	#FF000000��63      
BlurRadius$ 8Q�6E      Opacity$ 1Q�6T   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $
��Left=�6V   .+�5      �� -   5        $��btn_Play��5      $��20��6%   $��20��60   $��5q�6<   .��6^   ▶6a   �� 5      -   5        $��	btn_Pause��5      $��20��6&   $��20��61   $��5q�6=   .��6`   ||6d   5      5      5      