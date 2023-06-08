namespace C5;

internal delegate R Fun<R>();
internal delegate R Fun<A1, R>(A1 x1);
internal delegate R Fun<A1, A2, R>(A1 x1, A2 x2);
internal delegate R Fun<A1, A2, A3, R>(A1 x1, A2 x2, A3 x3);
internal delegate R Fun<A1, A2, A3, A4, R>(A1 x1, A2 x2, A3 x3, A4 x4);
