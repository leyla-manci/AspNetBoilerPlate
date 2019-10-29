import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import {
    MatDialogRef,
    MAT_DIALOG_DATA,
    MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
    ScreenServiceProxy,
    GetScreenOutput,
    ScreenEditDto,
    PermissionDto
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-screen-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class EditScreenDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    screen: ScreenEditDto = new ScreenEditDto();
   // public screenId: number ;
    permissions: PermissionDto[] = [];
    grantedPermissionNames: string[] = [];
    checkedPermissionsMap: { [key: string]: boolean } = {};

    constructor(
        injector: Injector,
        private _screenService: ScreenServiceProxy,
        private _dialogRef: MatDialogRef<EditScreenDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

    ngOnInit(): void {

    

        
        this._screenService
            .getScreenForEdit(this._id)
            .subscribe((result: GetScreenOutput) => {
                this.screen = result.screen;
                // console.log(this.screen.name);
                console.log("-result " + this.screen.name);
            });
    }

    setInitialPermissionsStatus(): void {
        _.map(this.permissions, item => {
            this.checkedPermissionsMap[item.name] = this.isPermissionChecked(
                item.name
            );
        });
    }

    isPermissionChecked(permissionName: string): boolean {
        return _.includes(this.grantedPermissionNames, permissionName);
    }

    onPermissionChange(permission: PermissionDto, $event: MatCheckboxChange) {
        this.checkedPermissionsMap[permission.name] = $event.checked;
    }

    getCheckedPermissions(): string[] {
        const permissions: string[] = [];
        _.forEach(this.checkedPermissionsMap, function (value, key) {
            if (value) {
                permissions.push(key);
            }
        });
        return permissions;
    }

    save(): void {
        this.saving = true;

       // this.screen.grantedPermissions = this.getCheckedPermissions();

        this._screenService
            .update(this.screen)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
