public static void indexedCaptureTest(){//jdk6之前的使用方式
        String names = "fred or barney";
        Matcher m = Pattern.compile("(\\w+) or (\\w+)").matcher(names);
        if(m.find()){
            System.out.println(m.group(1)+","+m.group(2));
        }
    }
    public static void namedCaptureTest(){//jdk7可以给捕获组命名
        String names = "fred or barney";
        Matcher m = Pattern.compile("(?<name1>\\w+) or (?<name2>\\w+)").matcher(names);
        if(m.find()){
            System.out.println(m.group("name1")+","+m.group("name2"));
        }
    }

    public static void indexedCaptureReplace(){
        String input = "aabbbccdddef";
        String regex = "((.)+?)(?!\\2)";
        String temp = input.replaceAll(regex, "$1,");
        String[] arr = temp.split(",");
        System.out.println(java.util.Arrays.toString(arr));
    }
    public static void namedCaptureReplace(){
        String input = "aabbbccdddef";
        String regex = "(?<name2>(?<name1>.)+?)(?!\\k<name1>)";//好丑陋的实现！ugly！
        String temp = input.replaceAll(regex, "${name2},");
        String[] arr = temp.split(",");
        System.out.println(java.util.Arrays.toString(arr));
    }