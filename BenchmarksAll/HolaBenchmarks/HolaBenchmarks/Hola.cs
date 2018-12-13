using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Pex.Framework;
using System.Diagnostics;
using PexAPIWrapper;

namespace HolaBenchmarks
{
    public class Hola
    {
        /*
         * https://bitbucket.org/nguyenthanhvuh/dig2_hg/src/0af40089f3741fc4845a36531aacb2a0ae2de50e/programs/hola/01.dig.c?at=default&fileviewer=file-view-default 
         * Precondition: n > 0 && n < 31
         * To prevent overflow of y;
         */
        public void dig01(int n)
        {
            int x = 1;
            int y = 1;
            int j = 0;

            while (j < n)
            {
                int t1 = x;
                int t2 = y;
                x = t1 + t2;
                y = t1 + t2;
                j = j + 1;
            }
            //NotpAssume.IsTrue(y >= 1);
            if (y < 1)
                throw new ArgumentException(); //assert(y >= 1);
            
        }

        public void dig02(int n)
        {
            int i = 1;
            int j = 0;
            int z = i - j;
            int x = 0;
            int y = 0;
            int w = 0;
            int u = 0;

            while (u < n)
            {
                z += x + y + w;
                y++;
                if (z % 2 == 1) x++;
                w += 2;
                u = u + 1;
            }
            
            if (x != y)
                throw new ArgumentException();

            
        }

        public void dig03(int i, int n, int l)
        {
            //assert(l >0)
            int t = 0;
            int k = 0;

            for (k = 1; k < n; k++)
            {

                for (i = l; i < n; i++)
                {
                    t = t + 1;
                }

                for (i = l; i < n; i++)
                {
                    t = t + 1;
                }
            }
           
        }
        public void dig05(int flag, int n)
        {
            int j = 0;
            int i = 0;
            int x = 0;
            int y = 0;
            int u = 0;

            while (u < n)
            {
                u++;
                x++;
                y++;
                i += x;
                j += y;
                if (flag != 0) j += 1;
            }

            if (j < i)
                throw new ArgumentException();

        }

        public void dig06(int n1, int n2)
        {
            int w = 1;
              int z = 0;
              int x = 0;
              int y = 0;
              int i1 = 0;
              int i2 = 0;

              while (i1 < n1) {
    
                i2 = 0;
                while (i2 < n2) {

                  if (w % 2 == 1) x++;
                  if (z % 2 == 0) y++;
                  i2++;
                }

                z = x + y;
                w = z + 1;
                i1++;
              }
               //%%%traces: int x, int y
               if(x != y)throw new ArgumentException();
        }

        public void dig07(int n, int u1)
        {
            //assert(n >= 0&& u1 > 0);
            int a = 0;
            int b = 0;
            int i = 0;
            int u = 0;

            while (i < n)
            {
                if (u < u1)
                {
                    a = a + 1;
                    b = b + 2;
                }
                else
                {
                    a = a + 2;
                    b = b + 1;
                }
                i = i + 1;
                u++;
            }
            //NotpAssume.IsTrue(a + b == 3 * n);
            if (a + b != 3 * n) throw new ArgumentException();
        }
        public void dig08(int u1, int u2, int u3)
        {

            int x = 0;
            int y = 0;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;

            while (i1 < u1)
            {
                i1++;
                i2++;
                i3++;
                if (i2 < u2)
                {
                    x++;
                    y += 100;
                }
                else if (i3 < u3)
                {
                    if (x >= 4)
                    {
                        x++;
                        y++;
                    }
                    if (x < 0)
                    {
                        y--;
                    }
                }
            }

            if(x >= 4 && y <= 2) throw new ArgumentException();
        }

        public void dig09(int j, int n, int t, int pvlen, int u1, int u2, int u3)
        {
            int k = 0;
            int i = 0;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;

            //  pkt = pktq->tqh_first;
            while (i1 < u1)
            {
                i1 = i1 + 1;
                i = i + 1;
            }

            if (i > pvlen)
            {
                pvlen = i;
            }
            else
            {
            }
            i = 0;

            while (i2 < u2)
            {
                i2 = i2 + 1;
                t = i;
                i = i + 1;
                k = k + 1;
            }

            while (i3 < u3)
            {
                i3 = i3 + 1;
            }

            j = 0;
            n = i;

            //%%%traces: int k
            if(k < 0)throw new ArgumentNullException();
            k = k - 1;
            i = i - 1;
            j = j + 1;
            while (j < n)
            {
                //%%%traces: int k
                if(k < 0) throw new ArgumentException();
                k = k - 1;
                i = i - 1;
                j = j + 1;
            }
        }

        public void dig10(int u1){
          //assert(u1 > 0);
          int i1 = 0;
          int w = 1;
          int z = 0;
          int x = 0;
          int y = 0;

          while (i1 < u1) {
            i1++;
            if (w == 1) {
              x++;
              w = 0;
            };
            if (z == 0) {
              y++;
              z = 1;
            };
          }

          //%%%traces: int x, int y
          //assert(x == y);
          if (x != y) throw new ArgumentNullException();
        }

        public void dig11( ){
          int j = 0;
          int x = 100;
          int i = 0;

          for (i = 0; i < x; i++) {
            j = j + 2;
          }
          //%%%traces: int j, int x, int i
          //assert(j == 2 * x);
          if (j != 2 * x)throw new ArgumentException();
        }

        public void dig12(int x, int y, int flag, int u1, int u2){
          //assert(u1 > 0);
          int t = 0;
          int s = 0;
          int a = 0;
          int b = 0;
          int i1 = 0;

          while (i1 < u1) {
            i1++;
            a++;
            b++;
            s += a;
            t += b;
            if (flag != 0) {
              t += a;
            }
          }

          //%%%traces: int s, int t
          // 2s >= t
          x = 1;
          if (flag != 0) {
            x = t - 2 * s + 2;
          }

          //%%%traces: int x
          // x <= 2
          y = 0;
          while (y <= x) {
            if (u2 != 0)
              y++;
            else
              y += 2;
          }
          //%%%traces: int y
          //assert(y <= 4);
          if (y > 4) throw new ArgumentException();
        }

        public void dig13(int flag, int u1){
          //assert(u1 > 0);
          int j = 2;
          int k = 0;
          int i0 = 0;

          while (i0 < u1) {
            i0++;
            if (flag != 0)
              j = j + 4;
            else {
              j = j + 2;
              k = k + 1;
            }
          }

          //%%%traces: int j, int k
          //if (k != 0) assert(j == 2 * k + 2);
          if (k != 0 && (j != 2 * k + 2)) throw new ArgumentException();

        }

        public void dig14(int m, int u4){
          //assert(m > 0);

          int a = 0;
          int j = 0;
          for (j = 1; j <= m; j++) {
            if (u4!=0)
              a++;
            else
              a--;
          }

          //%%%traces: int a, int m
          //assert(a >= 0 - m);
          NotpAssume.IsTrue(a >= 0 - m);
          
           if (a < 0 - m) throw new ArgumentException();
          //assert(a <= m);
           NotpAssume.IsTrue(a <= m);

           if (a > m) throw new ArgumentNullException();
        }

        public void dig15(int n, int k){
          //assert(n > 0);
          //assert(k > 
          int j = 0;
          while (j < n) {
            j++;
            k--;
          }
          //%%%traces: int k, int n
          //assert(k >= 0);
          //NotpAssume.IsTrue(k>=0);
          
            if (k < 0) throw new ArgumentException();
          //Debug.Assert(false);
        }

        public void dig16(int i, int j){
          int x = i;
          int y = j;

          while (x != 0) {
            x--;
            y--;
          }
          //%%%traces: int i, int j, int y
          // if (i == j) assert(y == 0);
          if (i == j && y != 0) throw new ArgumentException();
        }

        public void dig17(int n){
          //assert(n > 0);
          int k = 1;
          int i = 1;
          int j = 0;

          while (i < n) {
            j = 0;
            while (j < i) {
              k += (i - j);
              j++;
            }
            i++;
          }
          //%%%traces: int k, int n
          //assert(k >= n);
          if (k < n) throw new ArgumentException();
        }

        public void dig18(int a, int b, int flag){
          int j = 0;
          for (b = 0; b < 100; ++b) {
            if (flag != 0) j = j + 1;
          }

          //%%%traces: int j, int flag, int a, int b
          //if (flag != 0) assert(j == 100);
          if (flag != 0 && j != 100 ) throw new ArgumentException();
        }

        public void dig19(int m, int n){
          //assert(n >= 0);
          //assert(m >= 0);
          //assert(m < n);

          int x = 0;
          int y = m;

          while (x < n) {
            x++;
            if (x > m) y++;
          }

          //%%%traces: int y, int n
          //assert(y == n);
          //NotpAssume.IsTrue(y == n);
          if (y != n)throw new ArgumentException();
        }

        public void dig20(int k, int x, int y, int i, int n, int u1){
          //assert((x + y) == k);

          int m = 0;
          int j = 0;
          while (j < n) {
            if (j == i) {
              x++;
              y--;
            } else {
              y++;
              x--;
            }
            if (u1!=0) m = j;
            j++;
          }

          //%%%traces: int x, int y, int k, int n, int m
          //assert((x + y) == k);
          //if (n > 0) {
          //  //assert(0 <= m);
          //  //assert(m < n);
          //}
          // P && ~Q || ~R
          if (n > 0 && (0 > m || m >= n)) throw new ArgumentException();
        }

        public void dig21(int n, int j, int v, int u4){
          //assert(n > 0);
          //assert(n < 10);

          int c1 = 4000;
          int c2 = 2000;

          int k = 0;
          int i = 0;
          while (i < n) {
            i++;
            if (u4!=0)
              v = 0;
            else
              v = 1;

            if (v == 0)
              k += c1;
            else
              k += c2;
          }

          //%%%traces: int k, int n, int j, int v
          // assert(k > n);
          //NotpAssume.IsTrue(k > n);
          if (k <= n) throw new ArgumentException(); 
        }


        public void dig29(int u1, int u2){
          //assert(u1 > 0 && u2 > 0);
          int a = 1;
          int b = 1;
          int c = 2;
          int d = 2;
          int x = 3;
          int y = 3;
          int i1 = 0;
          int i2 = 0;

          while (i1 < u1) {
            i1++;
            x = a + c;
            y = b + d;

            if ((x + y) % 2 == 0) {
              a++;
              d++;
            } else {
              a--;
            }
    
            i2 = 0;
            while (i2 < u2 ) {
              i2++;
              c--;
              b--;
            }
          }
  
          //%%%traces: int a, int b, int c, int d
          //assert(a + c == b + d);
          if (a + c != b + d) throw new ArgumentException();
        }

        public void dig30(){
          int i = 0;
          int c = 0;

          while (i < 1000) {
            c = c + i;
            i = i + 1;
          }

          //%%%traces: int c, int i
          //assert(c >= 0);
          if (c < 0) throw new ArgumentException();
        }

        public void dig31(int m, int n, int u1){
          //assert(m + 1 < n);
          int i = 0;
          int j = 0;
          int k = 0;
          for (i = 0; i < n; i += 4) {

            for (j = i; j < m;) {

              if (u1 != 0) {
                //%%%traces: int j
                //assert(j >= 0);
                  if (j < 0) throw new ArgumentException();
                j++;
                k = 0;
                while (k < j) {
                  k++;
                }
              } else {
                //%%%traces: int n, int j, int i
                //assert(n + j + 5 > i);
                  //NotpAssume.IsTrue(n + j + 5 <= int.MaxValue);
                  //NotpAssume.IsTrue(n + j + 5 > i);
                  if (n + j + 5 <= i) { throw new ArgumentNullException(); }
                j += 2;
              }
            }
          }
          //%%%traces: int n, int j, int i
        }

        

        public void dig35(int n){
          int x = 0;
          while (x < n) {
            x++;
          }

          //%%%traces: int x, int n
          //if (n > 0) assert(x == n);
          if (n > 0 && x != n) throw new ArgumentException();
        }

        public void dig36(int flag, int u1, int u2, int u3){
          //assert(u1 > 0 && u2 > 0 && u3 > 0);
          int a = 0;
          int b = 0;
          int j = 0;
          int w = 0;
          int x = 0;
          int y = 0;
          int z = 0;
          int i1 = 0;
          int i2 = 0; 
          int i3 = 0;

          while (i1 < u1) {
            i1++;
            int i = z;
            j = w;
            int k = 0;

            while (i < j) {
              k++;
              i++;
            }

            x = z;
            y = k;

            if (x % 2 == 1) {
              x++;
              y--;
            }

            i2 = 0;
            while (i2 < u2) {
              i2++;
              if (x % 2 == 0) {
                x += 2;
                y -= 2;
              } else {
                x--;
                y--;
              }
            }

            z++;
            w = x + y + 1;
          }

          int c = 0;
          int d = 0;
          i3 = 0;
          while (i3 < u3) {
            i3++;
            c++;
            d++;
            if (flag != 0) {
              a++;
              b++;
            } else {
              a += c;
              b += d;
            }
          }

          //%%%traces: int w, int z, int a, int b
          //assert(w >= z && a - b == 0);
          if (w < z || a - b != 0) throw new ArgumentException();
        }

        public void dig37(int n, int u1){
          //assert(u1 > 0);
          int x = 0;
          int m = 0;

          while (x < n) {
            if (u1!= 0) {
              m = x;
            }
            x = x + 1;
          }

          //%%%traces: int n, int m, int x
          //if (n > 0) assert(0 <= m && m < n);
          if (n > 0 && (0 > m || m >= n) ) throw new ArgumentException();
        }

        public void dig38(int n){
          int x = 0;
          int y = 0;
          int i = 0;

          while (i < n) {
            i++;
            x++;
            if (i % 2 == 0) y++;
          }
          //%%%traces: int i, int x, int y
          //if (i % 2 == 0) assert(x == 2 * y);
          if (i % 2 == 0 && x != 2 * y) throw new ArgumentException();
        }

        public void dig39(int MAXPATHLEN, int u){
          //assert(MAXPATHLEN > 0);

          int buf_off = 0;
          int pattern_off = 0;
          
          NotpAssume.IsTrue(MAXPATHLEN < int.MaxValue );
          int bound_off = 0 + (MAXPATHLEN + 1) - 1;

          int glob3_pathbuf_off = buf_off;
          int glob3_pathend_off = buf_off;
          int glob3_pathlim_off = bound_off;
          int glob3_pattern_off = pattern_off;

          int glob3_dc = 0;
          int flag = 0;

          if (glob3_pathend_off + glob3_dc >= glob3_pathlim_off)
            flag = 0;
          else
            flag = 1;
          while (flag != 0) {

            glob3_dc++;
            //%%%traces: int glob3_dc, int MAXPATHLEN
            //assert(0 <= glob3_dc);
            if (0 > glob3_dc) throw new ArgumentException();
            //assert(glob3_dc < MAXPATHLEN + 1);
            
            NotpAssume.IsTrue(glob3_dc < MAXPATHLEN + 1);
            if (glob3_dc >= MAXPATHLEN + 1) throw new ArgumentNullException();

            if (u != 0)
              flag = 0;
            else if (glob3_pathend_off + glob3_dc >= glob3_pathlim_off)
              flag = 0;
            else
              flag = 1;
          }
        }

        public void dig40(int flag, int u1, int u2){
          //assert(u1 > 0 && u2 > 0);

          int j = 1;
          int i = 0;
          if (flag != 0) {
            i = 0;
          } else {
            i = 1;
          }

          int i1 = 0;
          while (i1 < u1) {
            i1++;
            i += 2;
            if (i % 2 == 0) {
              j += 2;
            } else
              j++;
          }

          int a = 0;
          int b = 0;

          int i2 = 0;
          while (i2 < u2) {
            i2++;
            a++;
            b += (j - i);
          }

          //%%%traces: int a, int b, int i, int j
          //if (flag != 0) assert(a == b);
          if (flag != 0 && a != b) throw new ArgumentException();
        }

        public void dig41(int n, int kt, int flag){
          //assert(n >= 0);
          int k = 1;
          if (flag != 0) {
            //assert(kt >= 0);
              //NotpAssume.IsTrue(kt>=0);
            if (kt < 0) throw new ArgumentException();
            k = kt;
          }
          int i = 0;
          int j = 0;

          while (i <= n) {
            i++;
            j += i;
          }

          int z = k + i + j;
          //%%%traces: int z, int n, int i, int j
          //assert(z > 2 * n);
          //NotpAssume.IsTrue(z > 2 * n);
          if (z <= 2 * n) throw new ArgumentException();
        }

        public void dig42(int flag, int u1){
          //assert(u1 > 0);
          int x = 1;
          int y = 1;
          int a = 0;

          if (flag != 0)
            a = 0;
          else
            a = 1;

          int i1 = 0;
          while (i1 < u1) {
             i1++;

            if (flag != 0) {
              a = x + y;
              x++;
            } else {
              a = x + y + 1;
              y++;
            }
            if (a % 2 == 1)
              y++;
            else
              x++;
          }
          // x==y

          if (flag != 0) a++;
          //%%%traces: int a, int y, int x
          //assert(a % 2 == 1);
          if (a % 2 != 1) throw new ArgumentException();
        }

        public void dig43(int x, int y, int u1){
          //assert(u1 > 0);
          //assert(x != y);

          int i = 0;
          int t = y;

          while (i < u1) {
            i++;
            if (x > 0) {
                //NotpAssume.IsTrue(y + x < int.MaxValue);
                y = y + x; }
          }
          //%%%traces: int y, int t, int i
          //assert(y >= t);
          //NotpAssume.IsTrue(y >= t);
          if (y < t) throw new ArgumentException();
        }


        public void dig45(int flag, int u1, int u2, int u3){
          //assert(u1 > 0 && u2 > 0 && u3 > 0);
          int x = 0;
          int y = 0;
          int j = 0;
          int i = 0;
          int c = 0;
          int d = 1;
  
          int i1 = 0;
          while (i1 < u1) {
            i1++;
            x++;
            y++;
            i += x;
            j += y;
            if (flag != 0) {
              j += 1;
            }
          }

          if (j >= i)
            x = y;
          else
            x = y + 1;

          int w = 1;
          int z = 0;
          int i2 = 0;
          while (i2 < u2 ) {
            i2++;
            int i3 = 0;
            while (i3 < u3) {
              i3++;
              if (w % 2 == 1) x++;
              if (z % 2 == 0) y++;
            }

            z = x + y;
            w = z + 1;
          }

          //%%%traces: int x, int y
          //assert(x == y);
          if (x != y) throw new ArgumentException();
        }

        public void dig46(int u1){
          //assert(u1 > 0);
          int w = 1;
          int z = 0;
          int x = 0;
          int y = 0;
          int i1 = 0;
          while (i1 < u1) {
            i1++;
            if (w % 2 == 1) {
              x++;
              w++;
            };
            if (z % 2 == 0) {
              y++;
              z++;
            };
          }
          //%%%traces: int x, int z, int y, int w
          //assert(x <= 1);
          if (x > 1) throw new ArgumentException();
        }



    }
}
