   M S B A M L   `   `   `  ����D  @WeatherAp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WeatherAp	WeatherAp  5   	       WeatherAp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:WeatherAp     5   	     � Title$  Weather App��5   	   $	��450��6   $	��800��6*   .��5      �  � RowDefinitions 5	   
   �� 5
      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   ��5      �� 5       �� ImageSource$M GC:\Users\sayef\Downloads\white-clouds-blue-background_23-2148964575.jpg��6    j� Stretch$ UniformToFill=�6s   .+�5      �� -   5         ��Name$ Condition_0��5      $
��Left=�6+   $��325,163,0,0q�6F    �� TextWrapping$
 Wrap=�6[   $��	Condition��6o   $	��Top=�6�   $��94��6�   5      � 5   
   $��0��6   $��1��6   $��10q�6,   .+�5      �� -   5         ��Name$ 	CB_Villes��5      $��	10,10,0,0q�6+   $
��Left=�6?   $	��Top=�6Z   $	��200��6r   $��30��6~   6�   5      � 5!   
   -   5         �Name$	 BTN��5!      $��1��6   $��2��6)   $��10q�6=   .+�5#      �� $"��Météo des 4 jours suivants��6   $��16(�6:   $
��Bold"�6H   �� 5$      -   5        $ Previsions_0��5$      $
��Left=�6,   $��315,-168,0,0q�6G   $
 Wrap=�6]   $��Previsions
��6q   $	��Top=�6�   $��80��6�   $��34��6�    J� RenderTransformOrigin$ 0.462,0.501&�6�   �� 5%      -   5        $ Previsions_1��5%      $
��Left=�6,   $��
163,58,0,0q�6G   $
 Wrap=�6[   $��Previsions
��6o   $	��Top=�6�   $��80��6�   $��34��6�   �� 5&      -   5        $ Previsions_2��5&      $��Center=�6,   $��0,58,0,0q�6I   $
 Wrap=�6[   $��Previsions
��6o   $	��Top=�6�   $��80��6�   $��34��6�   �� 5'      -   5        $ Previsions_3��5'      $
��Left=�6,   $��
516,58,0,0q�6G   $
 Wrap=�6[   $��Previsions
��6o   $	��Top=�6�   $��80��6�   $��34��6�   �� 5(      -   5        $ Temp_0��5(      $
��Left=�6&   $��315,-195,0,0q�6A   $
 Wrap=�6W   $��Temperature��6k   $	��Top=�6~   $��94��6�   $ 0.483,-0.352&�6�   $��18��6�   �� 5)      -	   5        $ Temp_1��5)      $
��Left=�6&   $��
156,29,0,0q�6A   $
 Wrap=�6U   $��Temperature��6i   $	��Top=�6|   $��94��6�   �� 5*      -
   5        $ Temp_2��5*      $��Center=�6&   $��0,29,0,0q�6C   $
 Wrap=�6U   $��Temperature��6i   $	��Top=�6|   $��94��6�   �� 5+      -   5        $ Temp_3��5+      $
��Left=�6&   $��
509,29,0,0q�6A   $
 Wrap=�6U   $��Temperature��6i   $	��Top=�6|   $��94��6�   �� 5,      -   5        $ Condition_1��5,      $
��Left=�6+   $��156,162,0,0q�6F   $
 Wrap=�6[   $��	Condition��6o   $	��Top=�6�   $��94��6�   �� 5-      -   5        $ Condition_2��5-      $��Center=�6+   $��	0,162,0,0q�6H   $
 Wrap=�6[   $��	Condition��6o   $	��Top=�6�   $��94��6�   �� 5.      -   5        $ Condition_3��5.      $
��Left=�6+   $��509,162,0,0q�6F   $
 Wrap=�6[   $��	Condition��6o   $	��Top=�6�   $��94��6�   �� 5/      -   5        $ 	TempLow_1��5/      $
��Left=�6)   $��163,128,0,0q�6D   $
 Wrap=�6Y   $��TempLow��6m   $	��Top=�6|   $��80��6�   �� 50      -   5        $ 	TempMax_1��50      $
��Left=�6)   $��163,105,0,0q�6D   $
 Wrap=�6Y   $��TempMax��6m   $	��Top=�6|   $��80��6�   �� 51      -   5        $ 	TempMax_2��51      $��Center=�6)   $
 Wrap=�6F   $��TempMax��6Z   $	��Top=�6i   $��80��6�   $��	0,105,0,0q�6�   �� 52      -   5        $ 	TempLow_2��52      $��Center=�6)   $��	0,128,0,0q�6F   $
 Wrap=�6Y   $��TempLow��6m   $	��Top=�6|   $��80��6�   �� 53      -   5        $ 	TempMax_3��53      $
��Left=�6)   $��516,105,0,0q�6D   $
 Wrap=�6Y   $��TempMax��6m   $	��Top=�6|   $��80��6�   $ -0.002,0.495&�6�   �� 54      -   5        $ 	TempLow_3��54      $
��Left=�6)   $��516,128,0,0q�6D   $
 Wrap=�6Y   $��TempLow��6m   $	��Top=�6|   $��80��6�   �� 55      -   5        $ 	TempLow_0��55      $
��Left=�6)   $��315,-92,0,0q�6D   $
 Wrap=�6Y   $��TempLow��6m   $	��Top=�6|   $��80��6�   $��19��6�   �� 56      -   5        $ Search��56      $	��150��6&   $	��Top=�62   $��516,-143,114,0q�6J   �� 57      -   5        	 ��Name$	 Btn_Add��57      $��Ajouter��6&   $��477,-195,199,350q�6Q   $ 
0.05,0.429&�6k   �� 58      -   5        $	 	Btn_Suppr��58      $��	Supprimer��6(   $��594,-195,84,350q�6W   5;      �� 5<   
   -   5        $ 	TempMax_0��5<      $
��Left=�6%   $��	326,0,0,0q�6@   $
 Wrap=�6S   $��TempMax��6g   $��Center=�6v   $��80��6�   ��5>   
   �� 5@      $Y SC:\Users\sayef\Downloads\vivid-blurred-colorful-wallpaper-background_58702-3752.jpg��6   5B      5C      