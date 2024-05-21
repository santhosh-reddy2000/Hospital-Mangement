import { NzSafeAny } from 'ng-zorro-antd/core/types';
export declare type TransferDirection = 'left' | 'right';
export interface TransferItem {
    firstName: string;
    direction?: TransferDirection;
    disabled?: boolean;
    checked?: boolean;
    hide?: boolean;
    [key: string]: NzSafeAny;
}
export interface TransferCanMove {
    direction: TransferDirection;
    list: TransferItem[];
}
export interface TransferChange {
    from: TransferDirection;
    to: TransferDirection;
    list: TransferItem[];
}
export interface TransferSearchChange {
    direction: TransferDirection;
    value: string;
}
export interface TransferSelectChange {
    direction: TransferDirection;
    checked: boolean;
    list: TransferItem[];
    item?: TransferItem;
}
