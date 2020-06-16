import { AppService } from './app.service';
import { FormControl } from '@angular/forms';

// export function LandlinePortableValidator(appService: AppService) {
//   return async (control: FormControl) => {
//     if (control.value && control.value !== '') {
//       const isPortable = await isPostCodeValid(appService, control.value);
//       if (isPortable) {
//         return null;
//       } else {
//         return {
//           validateLandline: {
//             valid: false,
//             message: 'Number is not portable',
//           },
//         };
//       }
//     } else {
//       return null;
//     }
//   };
// }

// async function isPostCodeValid(
//   addressService: AppService,
//   serviceNumber: string
// ) {
//   let isPortable = false;
//   await addressService
//     .validatePostcode(serviceNumber)
//     .pipe(take(1))
//     .toPromise()
//     .then((response) => {
//       isPortable = response;
//     });
//   return isPortable;
// }
