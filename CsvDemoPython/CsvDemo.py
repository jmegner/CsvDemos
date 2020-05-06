import csv
import sys

if __name__ == "__main__":
    print("begin")

    for arg in sys.argv[1:]:
        print(f"reading file {arg}")

        with open(arg) as csv_file:
            parser = csv.reader(csv_file, delimiter=',')

            for line_idx, fields in enumerate(parser):
                fancy_fields = [("[EMPTY]" if len(f) == 0 else f) for f in fields]
                print(f"    line {line_idx + 1 :03}: {'  |  '.join(fancy_fields)}")

    print("end")
