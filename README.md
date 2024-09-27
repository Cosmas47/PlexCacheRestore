# PlexCacheRestore
WinForms Tool to Restore Photo Library from a Plex Thumbnail cache

So you're here because, like me, you f-ed up. Your NAS crashed hard and you lost all your precious family photos. Tragic.
The masters are gone, there's no undoing that.. but if you had your Photos imported in Plex and haven't touched it since the crash, you CAN export the thumbnails
out from Plex to rebuild the library with the help of the database. It's not a great solution, but we can agree that having all your memories back at low resolution is better than none at all. 

#How to Use the Tool
It's pretty straightforward.
- For the SQLITE file, you're going to point this towards the "com.plexapp.plugins.library.db" which is located in %APPDATA%\Local\Plex Media Server\Plug-in Support\Databases
- For the Cache Path, point this towards the root of your %APPDATA%\Local\Plex Media Server\Media\localhost folder
- The Output Path is the directory where you want to recreate everything.

Upon selecting the SQLITE file, the Selection to Export - will enable and let you select which 'Section' of your library to search for data.
"Types to Export" - Simply provides a means to drill down into specific file types. You shouldn't have a need to change this unless there's other formats I didn't account for.

Click Export when Ready.

#IMPORTANT
I was in a rush to build this and only had one night. ITS NOT EFFICIENTLY ENGINEERED. All the logic happens on the form, so once you click Export it will seem like it has crashed. I assure you, it hasn't it just doesn't do the export operation in a separate thread, so it locks up the form until its finished. You should recieve a 'Complete' popup once its done. Depending on how many files you had, it may take some time, so press it and walk away.

A talented engineer with a little more time than myself can probably take the source code and work it into somthing more robust.

#Wow.. these images are low res :(
Once you have your files back, you might consider an AI upscaler. I tried https://www.pixelcut.ai/ and it worked pretty good, but I don't recommend enhancing beyond 200%.

