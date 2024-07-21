export interface Device {
    id: string;
    name: string;
    serialNumber: string;
    categoryId?: string;
    categoryName: string;
    brandId:string;
    brandName: string;
    supplierId:string;
    supplierName: string;
    isFaulty: boolean;
  }
  