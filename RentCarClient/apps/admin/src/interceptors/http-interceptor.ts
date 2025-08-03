import { HttpInterceptorFn } from '@angular/common/http';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  const url = req.url;

  let clone = req.clone({
      url: url.replace("/rent/", "http://localhost:5212/")
  });
  return next(clone);
};
