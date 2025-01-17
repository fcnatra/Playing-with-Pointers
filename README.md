# Playing with pointers
Testing how to use pointers/reference in C#

> [!NOTE]
This is a test I wanted to do after reading this post: [https://em-tg.github.io/csborrow/](https://em-tg.github.io/csborrow/)

## Console result:

REF INPUT PARM `a = 0`

-- inside the method receiving the ref param --

`myPointer = 0` - adding 1 to it results in `1`

-- exiting the method returning same ref param received as a ref --

Reference received outside: `ref int stackedValueReceived: 1` and now `a = 1`


-- inside the method receiving the ref param --

List<int> v = [r, 2, 3], thus = [1, 2, 3] - where v[0] is `the *value of* ref input param`, which unlinks the ref input param

sp spans v, thus `sp = 1, 2, 3`

set r to point to sp[0], thus `r = 1`</br>
f is set with sp[0], thus `f = 1`

After adding a value to v</br>
<pre><code>        v = 1, 2, 3, 4</br>
        sp = 1, 2, 3</br>
        r = 1</br>
        f = 1</br>
</code></pre>
After v[0]++</br>
<pre><code>        v = 2, 2, 3, 4</br>
        sp = 1, 2, 3</br>
        r = 1</br>
        f = 1</br>
</code></pre>
After sp[0]++</br>
<pre><code>        v = 2, 2, 3, 4</br>
        sp = 2, 2, 3</br>
        r = 2</br>
        f = 1</br>
</code></pre>
-- exiting the method returning same ref param received as a ref --

After returning a reference to r into int `valueReturn: 2` and `a: 1`


REF INPUT PARM is now `stacked`

Stacked value is passed as a ref to the method

-- inside the method receiving the ref param --

List<int> v = [r, 2, 3], thus = [2, 2, 3] - where v[0] is `the *value of* ref input param`, which unlinks the ref input param

sp spans v, thus `sp = 2, 2, 3`

set r to point to sp[0], thus `r = 2`</br>
f is set with sp[0], thus `f = 2`

After adding a value to v</br>
<pre><code>        v = 2, 2, 3, 4</br>
        sp = 2, 2, 3</br>
        r = 2</br>
        f = 2</br>
</code></pre>
After v[0]++</br>
<pre><code>        v = 3, 2, 3, 4</br>
        sp = 2, 2, 3</br>
        r = 2</br>
        f = 2</br>
</code></pre>
After sp[0]++</br>
<pre><code>        v = 3, 2, 3, 4</br>
        sp = 3, 2, 3</br>
        r = 3</br>
        f = 2</br>
</code></pre>
-- exiting the method returning same ref param received as a ref --

After returning a reference to r into ref int `refReturn: 3` and `valueReturn: 2`

-------------------------------------------
