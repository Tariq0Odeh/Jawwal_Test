from moviepy.editor import VideoFileClip
import argparse
import os

# 5000k => 5Mbb
# 2000k => 2Mbb

def compressvideo(inputpath, bitrate='5000k'):
    
    with VideoFileClip(inputpath) as clip:
        outputpath = os.path.splitext(inputpath)[0] + '.mp4'
        clip.write_videofile(outputpath, codec='libx265', bitrate=bitrate, preset='ultrafast', threads=8)
    print(f"Video successfully compressed and saved as {outputpath}")

if __name__ == '__main__':
    parser = argparse.ArgumentParser(description='Compress video')
    parser.add_argument('input', help='Input video file')
    parser.add_argument('--bitrate', default='5000k', help='Bitrate for the output video (default: 5000k)')

    args = parser.parse_args()

    if not os.path.exists(args.input):
        print('Input file does not exist')
    else:
        compressvideo(args.input, args.bitrate)
