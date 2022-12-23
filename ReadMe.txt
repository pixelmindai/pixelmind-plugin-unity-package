**********************************
***    AI TEXTURE GENERATOR    ***
**********************************


HOW TO USE 
**********

In Editor Mode:

	1. Select a game object
	2. Click 'Add Component' in the 'Inspector' window
	3. Type 'AI Texture Generator' and add the component
	4. Enter a texture description, for example 'stone brick wall'
	5. If you don't want the material to be modified, uncheck 'Assign To Material'
	6. Click 'Calculate' 
	7. Optionally you can save your texture as a prefab now
	8. Done. Easy as that! :)

At Runtime:

	This component is not supposed to be used at run time. (But you can of course use the textures 
	at runtime that you create using this component.)


HOW DOES IT WORK?
*****************

The script uses text to image artificial intelligence to generate seamless textures for your verbal 
descriptions. The repeatable texture algorithm is from material_stable_diffusion by tommoore515, which
in turn is based on the Stable Diffusion open source text to image AI model.
When you click calculate, a machine learning model hosted at replicate.com will be fed with your 
texture description. It will 'dream' the texture according to how you described it.
When the computation is finished, the produced image is automatically converted to an unity Texture2D 
and optionally assigned as an Albedo texture of your game object.


LIMITATIONS
***********

Replicate.com is basically offering a free service, but when you use it intensively or they have very high
server load, they may occasionally queue or even block your calculations.
In this case you can start a paid subscription at replicate.com and enter the API Key in the corresponding 
field of the AI Texture Generator component, to make sure your calculations are still being performed and 
treated with priority.
The author of this unity package is neither affiliated with replicate.com nor with tommoore515 who created
the material_stable_diffusion model, nor with Stable Diffusion, which is the Open-Source text to image AI 
model this component is based on.


LICENSING
*********

As this component is using material_stable_diffusion and Stable Diffusion, it's use is subject to the 
license that can be found here: https://github.com/CompVis/stable-diffusion/blob/main/LICENSE
(Don't worry, it does not prohibit commercial use, but focusses on a fair and ethical use of artificial 
intelligence.)




