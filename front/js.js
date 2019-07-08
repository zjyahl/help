document.addEventListener('DOMContentLoaded',function(){
    console.log('3 seconds passed');
});
console.log(document.createElement("script").async); // true

const style = document.createElement("link");
style.rel = "stylesheet";
style.href = "index.css";
document.head.appendChild(style); // 阻塞？

var dataSortWorker = new Worker("sort-worker.js");
dataSortWorker.postMesssage(dataToSort);

// 主线程不受Web Workers线程干扰
dataSortWorker.addEventListener('message', function(evt) {
    var sortedData = e.data;

    // Web Workers线程执行结束
    // ...
});

var taskList = breakBigTaskIntoMicroTasks(monsterTaskList);
requestAnimationFrame(processTaskList);

function processTaskList(taskStartTime) {
    var nextTask = taskList.pop();

    // 执行小任务
    processTask(nextTask);

    if (taskList.length > 0) {
        requestAnimationFrame(processTaskList);
    }
}

requestAnimationFrame(logBoxHeight);
// 先写后读，触发强制布局
function logBoxHeight() {
    // 更新box样式
    box.classList.add('super-big');

    // 为了返回box的offersetHeight值
    // 浏览器必须先应用属性修改，接着执行布局过程
    console.log(box.offsetHeight);
}
// 先读后写，避免强制布局
function logBoxHeight() {
    // 获取box.offsetHeight
    console.log(box.offsetHeight);
    // 更新box样式
    box.classList.add('super-big');
}

function resizeWidth() {
    // 会让浏览器陷入'读写读写'循环
    for (var i = 0; i < paragraphs.length; i++) {
        paragraphs[i].style.width = box.offsetWidth + 'px';
    }
}
// 改善后方案
var width = box.offsetWidth;
function resizeWidth() {
    for (var i = 0; i < paragraphs.length; i++) {
        paragraphs[i].style.width = width + 'px';
    }
}

function onScroll(evt) {
    // Store the scroll value for laterz.
    lastScrollY = window.scrollY;
    // Prevent multiple rAF callbacks.
    if (scheduledAnimationFrame) {
        return;
    }

    scheduledAnimationFrame = true;
    requestAnimationFrame(readAndUpdatePage);
}
window.addEventListener('scroll', onScroll);